using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject player;
    public float speed = 0.3f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // move the car towards the player while looking at the player
        transform.LookAt(player.transform);
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}
