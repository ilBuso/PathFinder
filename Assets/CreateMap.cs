using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    public int n;
    public GameObject prefab;
    private bool done = true;

    void Start()
    {
        
    }

    void Update()
    {
        //Quadrato

        if (done)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    Instantiate(prefab, new Vector2(prefab.transform.localScale.x * j, i), Quaternion.identity);

                    Debug.Log("dentro");
                }
            }
            done = false;
        }
    }
}
