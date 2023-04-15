using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperAirplaneFlight : MonoBehaviour
{
    [SerializeField]
    private float planeSpeed, duration;
    private Vector3 forward;

    void Start()
    {
        //this forward defines the direction the plane is intially pointed, which is the desired path
        forward = transform.TransformDirection (Vector3.forward);
        //call coroutine to destroy after desired duration
        Destroy(gameObject, duration);
    }
    void FixedUpdate()
    {
        
        //then the airplane travels linearly on the vector 3 direction from the start
        transform.position += forward * Time.deltaTime * planeSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AirPlaneObstacle"))
        {
            //if the plane hits an obstacle before enemy, destroy plane
            Destroy(gameObject);
        }
    }


    
}
