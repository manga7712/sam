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
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    [SerializeField]
    string[] state;
    public string currentState;
    public int test;


    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentState = state[4];
    }


    void Update()
    {
        InputHandler();
        Debug.Log(isGrounded);
        changeAnim();
    }
    private void FixedUpdate()
    {
        JumpUpdate();
        Mouve();
    }

    void InputHandler()
    {
        mvnt = new Vector3(Input.GetAxis("Horizontal"),-2,0);

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

        }

    }
    void changeAnim()
    {
          if (isJumping == true) {

              if (Input.GetAxis("Horizontal")>0)
              {

                  if (currentState == state[4]) {//idle_r

                    ChangeAnimationState(state[2]);//jump_r
                    test = 2;

                  }else if (currentState == state[5] || currentState == state[3]){//idle_l   jump_l

                    ChangeAnimationState(state[6]);//l_vers_r_jump
                    test = 0;
                }

              }
              else if(Input.GetAxis("Horizontal") < 0)
              {
                  if (currentState == state[5] )//idle_l
                  {

                    ChangeAnimationState(state[3]);//jump_l
                    test = 3;
                }
                  else if (currentState == state[4] || currentState == state[2])//idle_r  jump_r
                  {

                    ChangeAnimationState(state[7]);//r_vers_l_jump
                    test = 1;
                }
              }
          }
          else if (isJumping == false)
          {

              if (Input.GetAxis("Horizontal") > 0)
              {

                  if (currentState == state[2])//jump_r
                  {

                    ChangeAnimationState(state[4]);//idle_r
                    test = 4;
                }
                  else if (currentState == state[5] || currentState == state[3])//idle_l  jump_l
                  {

                    ChangeAnimationState(state[0]);//l_vers_r
                    test = 0;
                }

              }
              else if (Input.GetAxis("Horizontal") < 0)
              {
                  if (currentState == state[3] )//jump_l
                  {

                    ChangeAnimationState(state[5]);//idle_l
                    test = 5;
                  }
                  else if (currentState == state[4] || currentState == state[2])// idle_r   jump_r
                  {

                    ChangeAnimationState(state[1]);//r_vers_l
                    test = 1;
                }
              }
        }
        

    }
    void ChangeAnimationState(string newState)
    {
        if (newState == currentState) return;

        currentState = newState;

        animator.Play(currentState);
    }
}
