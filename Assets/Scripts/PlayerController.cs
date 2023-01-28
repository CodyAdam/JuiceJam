using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float force = 0.3f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void onJump()
    {
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }
}
