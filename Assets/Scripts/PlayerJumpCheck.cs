using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class PlayerJumpCheck : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject tree;
    private bool onCooldown = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Default") || other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if (!onCooldown)
            {
                playerController.isGrounded = true;
                Vector3 treeRotation = tree.transform.rotation.eulerAngles;
                Vector3 playerRotation = playerController.transform.rotation.eulerAngles;
                treeRotation.x = 0;
                treeRotation.z = 0;
                playerRotation.x = 0;
                playerRotation.z = 0;
                tree.transform.rotation = Quaternion.Euler(treeRotation);
                playerController.transform.rotation = Quaternion.Euler(playerRotation);
                onCooldown = true;
                StartCoroutine(Cooldown());
            }
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(.3f);
        onCooldown = false;
    }
}
