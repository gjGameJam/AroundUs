using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperAirplaneFlight : MonoBehaviour
{
    [SerializeField]
    private GameObject crumpledPaperBall;
    [SerializeField]
    private float planeSpeed, duration, paperBallDuration;
    private Vector3 forward;
    private EnemyBehavior behave;
    private GameObject enemy;

    

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
        if (other.CompareTag("enemyTag"))
        {
            Debug.Log("paper airplane hit enemy");
            //if the plane hits an enemy,  plane (without turning plane into paper ball)
            Destroy(gameObject);
            //and destroy enemy (hopefully it can be called like this)
            Destroy(other.gameObject);

        }

        else if (other.CompareTag("AirPlaneObstacle"))
        {
            //if the plane hits an obstacle before enemy, destroy plane
            
            Transform ballPlacement = gameObject.transform;
            Destroy(gameObject);
            //then instantiate a cute lil paper ball that despawns after duration only if it hits an obstacle
            Destroy(Instantiate(crumpledPaperBall, ballPlacement.position, Random.rotation), paperBallDuration);
        }

        
    }


    
}
