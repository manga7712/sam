using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public AnimationCurve curve;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {

            saut();
        }
    }

    void saut()
    {
       
        transform.position = new Vector3(transform.position.x, curve.Evaluate(Time.deltaTime), transform.position.z);

    }
}
