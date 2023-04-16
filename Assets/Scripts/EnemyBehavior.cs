using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private Collider enemycollider;
    [SerializedField] private GameObject player;
    [SerializeField] private float speed;
    private Vector3 velocity;
    private Vector3 forward;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemycollider = GetComponent<Collider>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player);
        velocity = new Vector3(transform.forward.x, 0, transform.forward.z) * speed;
        rb.velocity = velocity;
    }
}
