using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float force = 0.3f;
    public bool isGrounded = false;
    public BoxCollider playerFeetCollider;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    public void onJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
