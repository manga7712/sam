using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controler : MonoBehaviour
{
    [SerializeField]
    private float speed ;
    private Vector3 mvnt;
    private Rigidbody2D rb;
    [SerializeField]
    private bool isJumping;
    public bool isGrounded;
    [SerializeField]
    private LayerMask layerMask;
    private float jumpingTime;
    [SerializeField]
    private AnimationCurve jumpCurve;
    public Sprite glowL;
    public Sprite glowD;
    private SpriteRenderer spriteRenderer;
    public Animator animator;

    
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }


    void Update()
    {
        InputHandler();
        Debug.Log(isGrounded);
        changeSprites();
    }
    private void FixedUpdate()
    {
        JumpUpdate();
        Mouve();
    }

    void InputHandler()
    {
        mvnt = new Vector3(Input.GetAxis("Horizontal"),-2,0);
        animator.SetFloat("Speed",Mathf.Abs(mvnt.x));

        if (Input.GetButtonDown("Jump"))
        {
            JumpStart();
        }
        if (Input.GetButtonUp("Jump"))
        {
            if (jumpingTime < 0.4f)
            {
                jumpingTime = 0.4f;
            }
        }
    }

    void Mouve()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.52f,layerMask);
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        rb.velocity = mvnt * speed * Time.fixedDeltaTime;
    }
    void JumpStart()
    {
        if (isJumping || !isGrounded)
        {
            return;
        }
        isJumping = true;
        animator.SetBool("IsJumping", true);
        jumpingTime = 0;
    }

    void JumpUpdate()
    {
        if (!isJumping)
        {
            return;
        }
        jumpingTime += Time.fixedDeltaTime;
        mvnt += new Vector3(0, jumpCurve.Evaluate(jumpingTime), 0);
        if (jumpingTime>jumpCurve.keys[jumpCurve.keys.Length-1].time && isGrounded)
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);

        }

    }
    void changeSprites()
    {
        if (Input.GetAxis("Horizontal")>0)
        {
            spriteRenderer.sprite = glowD;
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            spriteRenderer.sprite = glowL;
        }
        else
        {
         
        }
    }
}
