using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    protected int _health;
    public int health
    {
        get { return _health; }
        set
        {
            _health = value;
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

}
