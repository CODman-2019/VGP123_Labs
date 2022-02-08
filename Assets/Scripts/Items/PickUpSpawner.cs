using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public PickUp[] pickups;
    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, pickups.Length);

        Instantiate(pickups[index], transform.position, transform.rotation);
    }


}
