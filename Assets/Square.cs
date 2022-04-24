using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    //Start
    public static int w;
    public static bool placedStart;

    //End
    public static int e;
    public static bool placedEnd;

    //Go
    public static bool stop;
    private bool canGo;
    public static int value;
    public static float time = 1f;

    private void Update()
    {
        if (!stop && placedStart && !canGo)
        {
            StartCoroutine(Count());
        }
    }

    IEnumerator Count()
    {
        canGo = true;

        yield return new WaitForSeconds(time);
        value++;

        canGo = false;
    }
}
