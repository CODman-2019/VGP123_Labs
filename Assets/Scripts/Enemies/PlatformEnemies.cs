using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformEnemies : MonoBehaviour
{
    //public BoxCollider2D leftgroundCheck, rightGroundCheck;
    public float speed = 5f;
    int direction, dirForce;
    Rigidbody2D rb;
    bool move;
    public AudioClip deathClip;
    // Start is called before the first frame update
    void Start()
    {
        direction = Random.Range(-1, 2);
        if(direction == 0)
        {
            direction = 1;
        }
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * direction * Time.deltaTime, rb.velocity.y); ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Shot_P")
        {
            SoundManager.sound.SetAudioClip(deathClip);
            SoundManager.sound.playClip();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Edge")
        {
            direction *= -1;
        }
    }

}
