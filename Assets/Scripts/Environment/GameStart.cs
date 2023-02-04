using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public bool skipTutorial = false;
    public Camera PlayerCamera;
    public Camera CarCamera;
    public Spawner spawner;
    public GameObject car;
    public GameObject bill;
    public GameObject tuto;

    public GameObject player;

    private bool isStarted = false;
    private bool isTuto = false;
    // Start is called before the first frame update
    void Start()
    {
        if (skipTutorial)
        {
            StartGame();
        }
        else
        {
            PlayerCamera.enabled = false;
            CarCamera.enabled = true;
        }
    }

    void FixedUpdate()
    {
        // dist player car is less than 10
        if (Vector3.Distance(player.transform.position, car.transform.position) < 100)
        {
            TriggerTutorial();
        }

        if (!isStarted && car.GetComponent<CarController>().isDead)
        {
            StartGame();
        }

        if (isStarted)
        {
            Destroy(gameObject);
        }
    }
    void TriggerTutorial()
    {
        if (isTuto || isStarted)
            return;
        isTuto = true;
        tuto.SetActive(true);
    }

    public void StartGame()

    {
        if (isStarted)
            return;

        isStarted = true;
        PlayerCamera.enabled = true;
        CarCamera.enabled = false;
        spawner.start = true;
        tuto.SetActive(false);
        bill.SetActive(true);
    }
}
