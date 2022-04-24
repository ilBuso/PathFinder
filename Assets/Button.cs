using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public static bool start = false;

    public void Start()
    {
        start = !start;
    }
}
