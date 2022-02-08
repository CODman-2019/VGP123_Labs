using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerProjectile : MonoBehaviour
{
    public float speed = 4f;
    public float lifeSpan = 2f;

    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        if (lifeSpan <= 0) lifeSpan = 2f;

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);

        Destroy(gameObject, lifeSpan);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Player") || !collision.gameObject.CompareTag("Pickup") || !collision.gameObject.CompareTag("Collectable"))
            Destroy(gameObject);
    }
}
