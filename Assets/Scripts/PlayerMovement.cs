using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public int jumpForce;
    private bool isGrounded;
    private Rigidbody2D rb;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
       
    }
    void Move()
    {
        float xDisplacement = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(xDisplacement * speed, rb.velocity.y);

        Vector3 vec = new Vector3(xDisplacement, 0, 0);

        if (Math.Abs(rb.velocity.x) < 10)
            rb.AddForce(vec * speed);
        

        if(Math.Abs(rb.velocity.x) > 0)
            animator.SetBool("isWalking", true);
        else
            animator.SetBool("isWalking", false);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Water"))
        {
            GameEventSystem.Instance.PlayerGetDamage(3);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }



}
