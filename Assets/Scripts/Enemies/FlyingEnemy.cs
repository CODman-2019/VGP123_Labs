using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed;
    public int distance, axis;
    public float direction;
    public AudioClip deathClip;
    //public float min, max;

    int distanceConuter, targetSpot;

    // Start is called before the first frame update
    void Start()
    {
        //axis = Random.Range(0, 2);
        //direction = 1;
        distanceConuter = 0;
        //targetSpot = min;
    }

    // Update is called once per frame
    void Update()
    {
        if(axis == 0)
        {
            transform.Translate(speed * direction * Time.deltaTime, 0, 0);
            distanceConuter += 1;

        }
        else if(axis == 1)
        {
            transform.Translate(0, speed * direction * Time.deltaTime, 0);
            distanceConuter += 1;

        }
            if (distanceConuter == distance)
            {
                direction *= -1;
                distanceConuter = 0;
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shot_P")
        {
            SoundManager.sound.SetAudioClip(deathClip);
            SoundManager.sound.playClip();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
