using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    LayerMask groundMask;

    Animator anim;
    Rigidbody2D rb;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetInteger("direction", 1);
        anim.SetFloat("xVel", 0);
        anim.SetBool("isGrounded", true);
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = Input.GetAxisRaw("Horizontal");
        bool jump = Input.GetButtonDown("Jump");
        //anim.SetFloat()

        switch (xDir)
        {
            case 1:
            anim.SetInteger("direction", 1);
            anim.SetFloat("xVel", 1);
                break;
            case -1:
            anim.SetInteger("direction", -1);
            anim.SetFloat("xVel", -1);
                break;
            default:
            anim.SetFloat("xVel", 0);
                break;
        }


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundMask);

        if(isGrounded)
            anim.SetBool("isGrounded", true);
        else
            anim.SetBool("isGrounded", false);
        
        if (isGrounded && jump)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }

        if (Input.GetButton("Fire1"))
        {
            anim.SetBool("shoot", true);
        }
        else
        {
            anim.SetBool("shoot", false);
        }

        Debug.Log(xDir);
        rb.velocity = new Vector2(speed * xDir * Time.deltaTime, rb.velocity.y);
    }
}
