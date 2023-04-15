using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperAirplaneFlight : MonoBehaviour
{
    [SerializeField]
    private float planeSpeed, duration;

    void Start()
    {
        //gets the desired direction of travel
        //Transform Orientation = this.transform;
        //call coroutine to destroy after desired duration
        Destroy(gameObject, duration);
    }
    void FixedUpdate()
    {
        Vector3 forward = transform.TransformDirection (Vector3.forward);
        transform.position += forward * Time.deltaTime * planeSpeed;
    }


    
}
