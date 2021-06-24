using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controler : MonoBehaviour
{
    [SerializeField]
    private float speed ;
    private Vector3 mvntx;
    private Rigidbody2D rb;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        InputHandler();







    }
    private void FixedUpdate()
    {
        Mouve();
    }

    void InputHandler()
    {
        mvntx = new Vector3(Input.GetAxis("Horizontal"),0,0);
       

    }

    void Mouve()
    {

        rb.velocity = mvntx * speed * Time.fixedDeltaTime;


    }

}
