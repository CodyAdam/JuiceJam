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
        // move the car towards the player 
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);

        // rotate the car to look at the player in the Y axis only
        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(targetPosition);
    }
}
