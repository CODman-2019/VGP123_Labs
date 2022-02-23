using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damage;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (lifeTime <= 0)
            lifeTime = 2.0f;

        if (damage <= 0)
            damage = 2;

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        Destroy(gameObject, lifeTime);
    }

    //private void OnCollisionEnter2D(Collision2D col)
    //{
    //}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Level")
        {
            Destroy(gameObject);
        }
    }
}
