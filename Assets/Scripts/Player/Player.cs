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
    bool isGrounded, enviroDamage;

    public AudioClip hit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetInteger("direction", 1);
        anim.SetFloat("xVel", 0);
        anim.SetBool("isGrounded", true);
        enviroDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkHealth();
        float xDir = Input.GetAxisRaw("Horizontal");
        bool jump = Input.GetButtonDown("Jump");
        //anim.SetFloat()

        if(xDir < 0 && anim.GetInteger("direction") == 1 || xDir > 0 && anim.GetInteger("direction") == -1)
        {
            anim.SetInteger("direction", -anim.GetInteger("direction"));
            anim.SetFloat("xVel", 1 * xDir);
        }
        else if( xDir == 0 && anim.GetFloat("xVel") != 0)
        {
            anim.SetFloat("xVel", 0);
        }
        else if(xDir < 0 && anim.GetInteger("direction") == -1 || xDir > 0 && anim.GetInteger("direction") == 1)
        {
            anim.SetInteger("direction", anim.GetInteger("direction"));
            anim.SetFloat("xVel", 1 * xDir);

        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundMask);

        anim.SetBool("isGrounded", isGrounded);
        
        if (isGrounded && jump)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }

        //Debug.Log(xDir);
        rb.velocity = new Vector2(speed * xDir * Time.deltaTime, rb.velocity.y);
        //add lava damage

    }
    void TakePlayerHealth()
    {
        GameManager.manager.playerLives--;
        Debug.Log("Lives: " + GameManager.manager.playerLives);
        CanvasManager.canvasUI.UpdateHUD();
        checkHealth();
        SoundManager.sound.SetAudioClip(hit);
        SoundManager.sound.playClip();
    }

    void checkHealth()
    {
        if (GameManager.manager.playerLives <= 0)
            GameManager.manager.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Damage")
        {
            enviroDamage = true;
            StartCoroutine("EnivornmentDamage");
        }
        if(collision.gameObject.tag == "Finish")
        {
            GameManager.manager.Victory();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Shot_E")
        {
            TakePlayerHealth();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            enviroDamage = false;
            StopCoroutine("EnivornmentDamage");
            Debug.Log("out of lava");
        }
    }

    IEnumerator EnivornmentDamage()
    {
        Debug.Log("in lava");
        while (true)
        {
            yield return new WaitForSeconds(2f);
            if (enviroDamage)
            {
                //deal damage to player
                TakePlayerHealth();
                Debug.Log("in lava");
            }
        }
    }
}




/* old code
 
// old animator switch cases
        //switch (xDir)
        //{
        //    case 1:
        //        break;
        //    case -1:
        //    anim.SetInteger("direction", -1);
        //    anim.SetFloat("xVel", -1);
        //        break;
        //    default:
        //    anim.SetFloat("xVel", 0);
        //        break;
        //}


        if (isGrounded)
            anim.SetBool("isGrounded", true);
        else 
            anim.SetBool("isGrounded", false);
 
 */
