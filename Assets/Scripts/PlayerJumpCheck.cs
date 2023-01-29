using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpCheck : MonoBehaviour
{
    public PlayerController playerController;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Default") || other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            playerController.isGrounded = true;
        }
    }
}
