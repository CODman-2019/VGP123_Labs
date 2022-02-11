using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    
    enum type
    {
        Energy,
        Power,
        Missle,
        BlasterUG,
        MorphUG,
    }
    [SerializeField]
    type pickupType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (pickupType)
            {
                case type.Energy:
                    break;
                case type.Power:
                    break;
                case type.Missle:
                    break;
                case type.BlasterUG:
                    break;
                case type.MorphUG:
                    break;
            }


            Destroy(gameObject);
        }
    }


}
