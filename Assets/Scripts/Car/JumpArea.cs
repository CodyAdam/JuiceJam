using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class JumpArea : MonoBehaviour
{
    public CarController car;
    public GameObject playerAnchor;
    private GameObject player;
    private PlayerController playerController;
    private Rigidbody playerBody;
    public bool isAttached = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !car.isDead)
        {
            player = other.gameObject;
            playerBody = player.GetComponent<Rigidbody>();
            playerController = player.GetComponent<PlayerController>();
            Snap(player);
        }
    }

    void Snap(GameObject player)
    {
        ScoreManager.GetInstance().AddScore("Car roof damage", 450);
        player.transform.parent = car.transform;
        playerBody.isKinematic = true;
        isAttached = true;
        playerController.isSnapping = true;
        Rigidbody treeRb = playerController.tree.GetComponent<Rigidbody>();
        treeRb.constraints = RigidbodyConstraints.FreezeAll;
        // use dotween to move the player to the anchor position
        player.transform.DOLocalMove(playerAnchor.transform.localPosition, .1f).SetEase(Ease.InCubic).onComplete += () =>
        {
            playerController.isSnapping = false;
            playerController.isGrounded = true;
        };
    }


    public void Detach()
    {
        if (isAttached)
        {
            player.transform.DOKill();
            playerController.isSnapping = false;
            player.transform.parent = null;
            Rigidbody treeRb = playerController.tree.GetComponent<Rigidbody>();
            treeRb.constraints = RigidbodyConstraints.FreezePosition;
            if (!car.isDead)
            {
                car.OnDeath();
            }
            playerBody.isKinematic = false;
            isAttached = false;
        }
    }
}
