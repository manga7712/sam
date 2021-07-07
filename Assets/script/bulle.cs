using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulle : MonoBehaviour
{

    [SerializeField]
    private LayerMask layerMask;
    public bool dead;
    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.48f, layerMask);
        if (hit.collider != null)
        {
            dead = true;
           GameObject.Destroy(gameObject,2f);
        }
        else
        {

            dead = false;
        }
    }

}
