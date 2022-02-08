using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player), typeof(Animator))]
public class PlayerFire : MonoBehaviour
{
    [SerializeField]
    PlayerProjectile projectile;
    [SerializeField]
    GameObject leftShotPosition;
    [SerializeField]
    GameObject rightShotPosition;
    [SerializeField]
    GameObject aboveShotPosition;

    Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("fire", true);
            //FireBlaster();
        }
        else
        {
            anim.SetBool("fire", false);
        }

    }

    public void FireBlaster()
    {
            PlayerProjectile temp;
            if(anim.GetInteger("direction") > 0)
            {
            temp = Instantiate(projectile, rightShotPosition.transform.position, rightShotPosition.transform.rotation);
            }
            else if (anim.GetInteger("direction") < 0)
            {
                temp = Instantiate(projectile, leftShotPosition.transform.position, leftShotPosition.transform.rotation);
                temp.GetComponent<Rigidbody2D>().velocity *= -1;
            }
    } 
}
