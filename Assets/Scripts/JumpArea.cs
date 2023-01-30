using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;

public class JumpArea : MonoBehaviour
{
    public CarController car;
    public GameObject playerAnchor;
    private GameObject player;
    private Rigidbody playerBody;
    public bool isAttached = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !car.isDead)
        {
            player = other.gameObject;
            playerBody = player.GetComponent<Rigidbody>();
            Snap(player);
        }
    }

    void Snap(GameObject player)
    {
        player.transform.parent = car.transform;
        playerBody.isKinematic = true;
        isAttached = true;
        // use dotween to move the player to the anchor position
        // player.transform.position = playerAnchor.transform.position;
        // player.transform.rotation = playerAnchor.transform.rotation;

        player.transform.DOLocalMove(playerAnchor.transform.localPosition, .2f).SetEase(Ease.InCubic);
    }


    public void Detach()
    {
        if (isAttached)
        {
            player.transform.parent = null;
            if (!car.isDead)
            {
                car.OnDeath();
            }
            playerBody.isKinematic = false;
        }
        isAttached = false;
    }
}
