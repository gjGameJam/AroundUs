using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperAirplaneShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject paperAirplane;
    private float cooldownTimer = 0;
    [SerializeField]
    private static float cooldownTotal = 0.90f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //check if player wants to shoot
        if (Input.GetButtonDown("Fire1"))
        {
            //get the position of the sight (the floating cube)
            Transform sightPlacement = GameObject.FindWithTag("Sight").transform;
            //and check if shooting is off cooldown (timer is greater or equal to total cooldown time)
            if (cooldownTimer >= cooldownTotal)
            {
                //reset the cooldown for the shoot mechanic
                cooldownTimer = 0;
                //and spawn in a new paper airplane prefab relative to sight position
                //this prefab will fly by itself until it despawns or hits an enemy
                Instantiate(paperAirplane, sightPlacement.position, sightPlacement.rotation);
            }
            
        }
    }

    void FixedUpdate()
    {
        cooldownTimer += Time.deltaTime;

    }
}
