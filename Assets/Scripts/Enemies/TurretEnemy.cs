using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class TurretEnemy : MonoBehaviour
{
    [SerializeField] float projectileForce;
    [SerializeField] float projectileFireRate;
    [SerializeField] float fireRange;
    public AudioClip deathClip;

    float currentTime;

    protected int _health;
    SpriteRenderer sr;

    public Transform leftShootPosition;
    public Transform rightShootPosition;
    public EnemyProjectile projectilePrefab;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = projectileFireRate;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.x > this.transform.position.x)
        {
            if (!sr.flipX) 
            { 
                sr.flipX = !sr.flipX;
                Debug.Log("right");
            }
        }
        else
        {
            if (sr.flipX) 
            { 
                sr.flipX = !sr.flipX;
                Debug.Log("left");
            }
        }

        if(Time.time >= currentTime + projectileFireRate)
        {
            DistanceCheck();
            currentTime += Time.time;
        }
    }

    void DistanceCheck()
    {
        if(!sr.flipX && target.position.x > this.transform.position.x - fireRange)
        {
            Debug.Log("fire!!!");
            EnemyProjectile temp = Instantiate(projectilePrefab, leftShootPosition.position, leftShootPosition.rotation);
            temp.speed = -projectileForce;
        }
        else if (sr.flipX && target.position.x < this.transform.position.x + fireRange)
        {
            Debug.Log("fire!!!");
            EnemyProjectile temp = Instantiate(projectilePrefab, rightShootPosition.position, rightShootPosition.rotation);
            temp.speed = projectileForce;
        }
    }
    //private void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (col.gameObject.tag == "Shot_P")
    //    {
    //        SoundManager.sound.SetAudioClip(deathClip);
    //        SoundManager.sound.playClip();
    //        Destroy(gameObject);
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Shot_P")
        {
            SoundManager.sound.SetAudioClip(deathClip);
            SoundManager.sound.playClip();
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
