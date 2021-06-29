using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    public float vie = 3;
    public Vector3 check = new Vector3(-4.5f, -0.5f, 0);
    private bool back = false;
    public bool isCheck = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y < -10)
        {
            vie = 0;
        }
        if (vie == 0)
        {
            back = true;
        }
        if (isCheck == true)
        {
            check = transform.position;
            isCheck = false;
        }
    }
    public void FixedUpdate()
    {
        if (back == true)
        {
            tpBack();
        }
    }

    void tpBack()
    {
        transform.position = check;
        back = false;
        vie = 3;
    }
}
