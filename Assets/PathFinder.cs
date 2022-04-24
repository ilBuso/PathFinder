using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    private GameObject[] points;

    private bool stop;
    public int value;

    void Start()
    {

    }

    void Update()
    {
        //Assign
        stop = Square.stop;

        StartCoroutine(Path());

        if (stop)
        {

        }
    }

    IEnumerator Path()
    {
        if (gameObject.transform.CompareTag("Start") && !stop)
        {
            yield return new WaitForSeconds(Square.time);

            foreach (Transform child in gameObject.transform)
            {
                //Debug.Log(child.transform.name + " ---- " + child.transform.position + " ---- " + gameObject.transform.name);

                if (child.transform.CompareTag("Point"))
                {
                    RaycastHit2D hit = Physics2D.Raycast(child.transform.position, new Vector3(0f, 0f, 1f));

                    if (hit)
                    {
                        if (hit.transform.gameObject.CompareTag("Untagged"))
                        {
                            //Debug.Log(hit.transform.name);

                            hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                            hit.transform.gameObject.tag = "Start";

                            value = Square.value;
                        }
                        else
                        {
                            if (hit.transform.gameObject.CompareTag("End"))
                            {
                                Square.stop = true;
                            }
                        }
                    }
                }
            }
        }
    }
}