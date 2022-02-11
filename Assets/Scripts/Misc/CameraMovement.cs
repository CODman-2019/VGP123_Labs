using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float min, max;
    public Vector3 offset;
    bool isHorizontal;
    public Transform target;
        

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 xChange = target.position + offset;
        xChange.x = Mathf.Clamp(target.position.x, min, max);

        transform.localPosition = new Vector3(xChange.x, transform.position.y, transform.position.z);
    }
}
