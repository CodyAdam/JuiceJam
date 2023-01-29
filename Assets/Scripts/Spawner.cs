using System.Collections;
using System.Collections.Generic;
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
        float x = spawnRay * Mathf.Cos(angle);
        float z = spawnRay * Mathf.Sin(angle);
        return new Vector3(x, car.transform.localScale.y/2, z);
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
