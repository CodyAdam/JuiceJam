using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerController : MonoBehaviour
{
    public bool isGrounded = false;
    public float force;
    public JumpTricks tree;
    public bool isSnapping = false;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void onJump()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        if (isGrounded && !isSnapping) //si on est pas sur le sol, la fonction le fait rien
        {
            Vector3 newVelocity = rb.velocity;
            newVelocity.y = 0;
            rb.velocity = newVelocity;
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            tree.DoJumpTrick();
            isGrounded = false;
        }
    }
}
