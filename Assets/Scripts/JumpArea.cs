using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class JumpArea : MonoBehaviour
{
    public CarController car;
    public GameObject carHead;
    private GameObject player;
    private Rigidbody playerBody;
    bool isAttached = false;

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
