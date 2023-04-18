using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        //allow player to shoot off start
        cooldownTimer = cooldownTotal;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("spawn");
        //Instantiate(paperAirplane, new Vector3(1.48f,.1f,.5f), Random.rotation);
    }

    void FixedUpdate()
    {
        cooldownTimer += Time.deltaTime;
        
    }

    public void Shoot(InputAction.CallbackContext ctx) {
        //Debug.Log("Called");
        if (ctx.performed) {
            //Debug.Log("fire");
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

}
