using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject car;
    public float cooldown = 2f;
    public float speed = 0.3f;
    public GameObject player;
    public float spawnRay;


    void Start()
    {
        StartCoroutine(Spawn());
    }

    /**
    * Returns a random point on the perimeter of a circle with a radius of spawnRay
    * with a constant y value of 1
    */
    private Vector3 GetRandomPointOnPerimeter()
    {
        float angle = Random.Range(0, 360);
        Vector3 center = transform.position;
        center.y = 1;
        Vector3 pos;
        pos.x = center.x + spawnRay * Mathf.Sin(angle * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + spawnRay * Mathf.Cos(angle * Mathf.Deg2Rad);
        return pos;
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldown);
            // instantiate a car with player as CarController.player
            GameObject newCar = Instantiate(car, GetRandomPointOnPerimeter(), transform.rotation);
            newCar.GetComponent<CarController>().player = player;
            newCar.GetComponent<CarController>().speed = speed;
        }
    }
}
