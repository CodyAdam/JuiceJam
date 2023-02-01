using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEditor.SearchService;

public class JumpArea : MonoBehaviour
{
    public CarController car;
    public GameObject playerAnchor;
    public TextMeshProUGUI score;
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
        score.GetComponent<JumpScore>().score += 10;
        player.transform.parent = car.transform;
        playerBody.isKinematic = true;
        isAttached = true;
        // use dotween to move the player to the anchor position
        player.transform.DOLocalMove(playerAnchor.transform.localPosition, .1f).SetEase(Ease.InCubic);
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
