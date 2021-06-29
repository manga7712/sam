using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public bool coll = false;
    void Start()
    {
        
    }

    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        coll = true;
        GetComponent<life>().isCheck = true;
    }

}
