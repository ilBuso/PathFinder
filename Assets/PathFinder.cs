using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    private bool stop;
    public int value;

    void Start()
    {

    }

    void Update()
    {
        //Assign
        stop = Square.stop;

        if (gameObject.transform.CompareTag("Start") && !stop)
        {
            StartCoroutine(Path());
        }

        if (gameObject.transform.CompareTag("End") && stop)
        {
            foreach (Transform child in gameObject.transform)
            {
                if (child.transform.CompareTag("Point"))
                {
                    RaycastHit2D hit = Physics2D.Raycast(child.transform.position, new Vector3(0f, 0f, 1f));

                    if (hit)
                    {
                        if (hit.transform.gameObject.CompareTag("Start"))
                        {
                            if (hit.transform.gameObject.GetComponent<PathFinder>().value == Square.i - Square.n)
                            {
                                Square.n++;

                                hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                                hit.transform.gameObject.transform.tag = "End";

                                gameObject.transform.tag = "Player";

                            }
                        }
                    }
                }                              
            }
        }
    }

    IEnumerator Path()
    {
        yield return new WaitForSeconds(Square.time);

        foreach (Transform child in gameObject.transform)
        {
            if (child.transform.CompareTag("Point"))
            {
                RaycastHit2D hit = Physics2D.Raycast(child.transform.position, new Vector3(0f, 0f, 1f));

                if (hit)
                {
                    if (hit.transform.gameObject.CompareTag("Untagged"))
                    {
                        hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                        hit.transform.gameObject.transform.tag = "Start";
                        hit.transform.gameObject.GetComponent<PathFinder>().value = Square.value;
                    }
                    else
                    {
                        if (hit.transform.gameObject.CompareTag("End"))
                        {
                            hit.transform.gameObject.GetComponent<PathFinder>().value = (value + 1);

                            Square.stop = true;
                        }
                    }
                }
            }
        }
    }
}