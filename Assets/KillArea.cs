using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillArea : MonoBehaviour
{
    public CarController car;
    private void OnTriggerEnter(Collider other)
    {
        if (!car.isDead && (other.gameObject.tag == "Player" || other.gameObject.tag == "Car"))
        {
            car.OnDeath();
        }
    }
}
