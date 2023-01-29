using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject player;
    public JumpArea jumpArea;

    public float speed = 0.3f;

    public bool isDead = false;

    Rigidbody rb;

    public float ragdollForce = 5f;
    public float ragdollTorque = 5f;

    public float ragdollTime = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnDeath()
    {
        isDead = true;
        jumpArea.Detach();
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce(Vector3.up * ragdollForce, ForceMode.Impulse);
        rb.AddTorque(Vector3.right * ragdollTorque, ForceMode.Impulse);
        // remove collission from the car
        gameObject.layer = LayerMask.NameToLayer("Ragdoll");
        // start coroutine to destroy the car after a few seconds
        StartCoroutine(DestroyCar());
    }

    IEnumerator DestroyCar()
    {
        yield return new WaitForSeconds(ragdollTime);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (isDead)
            return;

        if (jumpArea.isAttached)
        {
            Vector3 rand = new Vector3(Random.value, Random.value, Random.value);
            // move the car towards the player 
            rb.AddForce(rand * speed, ForceMode.Impulse);

            // rotate the car to look at the player in the Y axis only
            transform.LookAt(rand);
        }

        else
        {
            // move the car towards the player 
            rb.AddForce(transform.forward * speed, ForceMode.Impulse);

            // rotate the car to look at the player in the Y axis only
            Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(targetPosition);
        }
    }
}
