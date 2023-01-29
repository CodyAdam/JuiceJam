using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isGrounded = false;
    public BoxCollider playerFeetCollider;
    public float force = 5f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    { //Si on est sur le sol, on peut autorise le saut
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Car")
        {
            isGrounded = true;
        }
    }

    public void onJump()
    {
        if (isGrounded) //si on est pas sur le sol, la fonction le fait rien
        {
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
