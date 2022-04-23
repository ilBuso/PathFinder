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

    private void Update()
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
            }
            else
            {
                if (spriteRenderer.color == Color.black)
                {
                    spriteRenderer.color = Color.white;
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

                Square.placedStart = !placedStart;
            }
            else
            {
                if(spriteRenderer.color == Color.yellow)
                {
                    spriteRenderer.color = Color.white;
                    Square.w--;

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

                Square.placedEnd = !placedEnd;
            }
            else
            {
                if (spriteRenderer.color == Color.red)
                {
                    spriteRenderer.color = Color.white;
                    Square.e--;

                    Square.placedEnd = !placedEnd;
                }
            }
        }           
    }
}
