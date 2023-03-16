using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControal : MonoBehaviour
{
    #region variables
    public float JumpPower = 7f;
    public float PlayerSpeed = 30.0f;
    public Transform groundcheckposition;
    private Rigidbody2D _rbody;

    public float newjumppowerx;

    public bool _isGrounded;

    private bool _jumped;

    public LayerMask enemy;

    private Animator _anim;
    #endregion

    
    private void Awake()
    {

             _rbody = GetComponent<Rigidbody2D>();
              _anim = GetComponent<Animator>();

    }//awake

    private void FixedUpdate()
    {
        playerwalk();
    }//fixedupdate

    private void playerwalk()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput>0)//goright
        {
            _rbody.velocity = new Vector2(PlayerSpeed, _rbody.velocity.y);
            _anim.SetInteger("Speed", 1);
            ChangeDirection(15);
        }
        else if (horizontalInput < 0)//goleft
        {
            _rbody.velocity = new Vector2(-PlayerSpeed, _rbody.velocity.y);
            _anim.SetInteger("Speed", 1);
            ChangeDirection(-15);

        }
        else
        {
            _rbody.velocity = new Vector2(0, _rbody.velocity.y);
            _anim.SetInteger("Speed", 0);

        }

    }//playerwalk

    private void ChangeDirection(int direction)
    {
        Vector3 tempscale = transform.localScale;
        tempscale.x = direction;
        transform.localScale = tempscale;




    }//changedirection

    // private void OnCollisionExit2D(Collision2D target)
    //{
    //if(target.gameObject.tag== "Enemy")
    // {
    //    Destroy(target.gameObject);
    // }
    // } 

    //private void OnTriggerEnter2D(Collider2D target)
    //
    //if (target.tag == "Enemy")
    //{
    // print("hello world");
    // }
    // }





    private void Update()
    {
       
        PlayerJump();


    }

    private void PlayerJump()
    {
        if (_isGrounded)
        {
              if (Input.GetKey(KeyCode.Space))
            {
                _jumped = true;
                newjumppowerx = (_rbody.velocity.x) + JumpPower;

                _rbody.velocity = new Vector2(newjumppowerx, JumpPower);
                _anim.SetBool("jump", true);   
            }

        }

    }

   


}//class