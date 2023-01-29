using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float force = 0.6f;
    public bool isGrounded = false;
    public BoxCollider playerFeetCollider;
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
