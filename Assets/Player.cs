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

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = Input.GetAxisRaw("Horizontal");
        bool jump = Input.GetButtonDown("Jump");

        rb.velocity = new Vector2(speed * xDir, rb.velocity.y);

        if (jump)
        {
            rb.AddForce(Vector2.up, ForceMode2D.Impulse);
        }
    }
}
