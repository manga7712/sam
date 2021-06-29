using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public bool coll = false;
    public GameObject Caca_sobre;
    void Start()
    {
        
    }

    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        coll = true;
        Caca_sobre.GetComponent<life>().isCheck = true;
    }

}
