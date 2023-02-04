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
    public bool start = false;
    bool hasStarted = false;

    private float selectedCooldown;
    private float selectedSpeed;

    void Start()
    {
        selectedCooldown = cooldown;
        selectedSpeed = speed;
    }

    void Update()
    {
        if (start && !hasStarted)
        {
            StartCoroutine(Spawn());
            hasStarted = true;
        }
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
            SelectParams();
            yield return new WaitForSeconds(selectedCooldown);
            // instantiate a car with player as CarController.player
            GameObject newCar = Instantiate(car, GetRandomPointOnPerimeter(), transform.rotation);
            newCar.GetComponent<CarController>().player = player;
            newCar.GetComponent<CarController>().speed = selectedSpeed;
        }
    }

    void SelectParams()
    {
        selectedCooldown = this.cooldown;
        selectedSpeed = this.speed;
        float score = ScoreManager.GetInstance().GetTotalCost();

        // to select : cooldown, speed
        if (score > 40000)
        {
            selectedCooldown = cooldown * 0.01f;
            selectedSpeed = speed * 5f;
        }
        else if (score > 20000)
        {
            selectedCooldown = cooldown * 0.1f;
            selectedSpeed = speed * 3f;
        }
        else if (score > 10000)
        {
            selectedCooldown = cooldown * 0.3f;
            selectedSpeed = speed * 2f;
        }
        else if (score > 5000)
        {
            selectedCooldown = cooldown * 0.5f;
            selectedSpeed = speed * 1.2f;
        }
    }
}
