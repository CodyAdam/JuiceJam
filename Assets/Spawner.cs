using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject car;
    public float cooldown = 2f;
    public float speed = 0.3f;
    public GameObject player;


    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldown);
            // instantiate a car with player as CarController.player
            GameObject newCar = Instantiate(car, transform.position, transform.rotation);
            newCar.GetComponent<CarController>().player = player;
            newCar.GetComponent<CarController>().speed = speed;
        }
    }
}
