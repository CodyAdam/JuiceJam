using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpTricks : MonoBehaviour
{
    private Rigidbody rb;
    public float rotationSpeed = 20f;
    public PlayerController player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void OnJump()
    {
        if (player.isGrounded)
        {
            rb.AddTorque(Vector3.up * rotationSpeed, ForceMode.Impulse);
            // make the Y scale bounce
            transform.DOScaleY(1.3f, 0.1f).SetEase(Ease.InCubic).OnComplete(() =>
            {
                transform.DOScaleY(1f, 0.1f).SetEase(Ease.OutCubic);
            });
        }
    }
}
