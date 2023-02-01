using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpTricks : MonoBehaviour
{
    private Rigidbody rb;
    public float rotationSpeed = 20f;
    public PlayerController player;

    public float scaleDuration = 0.1f;
    public float scaleForce = 1.3f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void DoJumpTrick()
    {
        if (player.isGrounded)
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.AddTorque(Vector3.up * rotationSpeed, ForceMode.Impulse);
            // make the Y scale bounce
            transform.DOScaleY(scaleForce, scaleDuration).SetEase(Ease.InCubic).OnComplete(() =>
            {
                transform.DOScaleY(1f, scaleDuration).SetEase(Ease.OutCubic);
            });
        }
    }
}
