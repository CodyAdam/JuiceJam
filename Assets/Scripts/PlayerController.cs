using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isGrounded = false;
    public BoxCollider playerFeetCollider;
    public float force;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    { //Si on est sur le sol, on peut autorise le saut
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        else if (other.gameObject.tag == "Car")
        {
            isGrounded = true;
            transform.IsChildOf(other.gameObject.transform);
            transform.position = transform.parent.position;
        }
    }

    public void onJump()
    {
        if (isGrounded) //si on est pas sur le sol, la fonction le fait rien
        {
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            isGrounded = false;
            transform.parent = null;
        }
    }
}
