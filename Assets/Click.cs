using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    //Start
    private int w;
    private bool placedStart;

    //End
    private int e;
    private bool placedEnd;

    void Update()
    {
        //Assign
        w = Square.w;
        placedStart = Square.placedStart;

        placedEnd = Square.placedEnd;
        e = Square.e;
    }

    private void OnMouseDown()
    {
        //Walls
        if (Input.GetKey(KeyCode.Q))
        {
            if (spriteRenderer.color == Color.white)
            {
                spriteRenderer.color = Color.black;

                transform.gameObject.tag = "Wall";
            }
            else
            {
                if (spriteRenderer.color == Color.black)
                {
                    spriteRenderer.color = Color.white;

                    transform.gameObject.tag = "Untagged";
                }
            }
        }
        

        //Start
        if (Input.GetKey(KeyCode.W))
        {
            if (!placedStart && w == 0 && spriteRenderer.color == Color.white)
            {
                spriteRenderer.color = Color.yellow;
                Square.w++;
                transform.gameObject.tag = "Start";

                Square.placedStart = !placedStart;
            }
            else
            {
                if(spriteRenderer.color == Color.yellow)
                {
                    spriteRenderer.color = Color.white;
                    Square.w--;
                    transform.gameObject.tag = "Untagged";

                    Square.placedStart = !placedStart;
                }
            }
        }


        //End
        if (Input.GetKey(KeyCode.E))
        {
            if (!placedEnd && e == 0 && spriteRenderer.color == Color.white)
            {
                spriteRenderer.color = Color.red;
                Square.e++;
                transform.gameObject.tag = "End";

                Square.placedEnd = !placedEnd;
            }
            else
            {
                if (spriteRenderer.color == Color.red)
                {
                    spriteRenderer.color = Color.white;
                    Square.e--;
                    transform.gameObject.tag = "Untagged";

                    Square.placedEnd = !placedEnd;
                }
            }
        }           
    }
}
