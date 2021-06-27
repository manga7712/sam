using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    public float vie = 3;
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y < -10)
        {
            vie = 0;
        }
    }
}
