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
    public GameObject spawner;
    public GameObject car;
    public Sprite newSprite;
    public Image bill;
    public TextMeshProUGUI tuto;
    // Start is called before the first frame update
    void Start()
    {
        if (skipTutorial)
        {
            PlayerCamera.enabled = true;
            CarCamera.enabled = false;
            spawner.GetComponent<Spawner>().start = true;
            bill.gameObject.SetActive(true);
            Destroy(gameObject);
        }
        else
        {
            PlayerCamera.enabled = false;
            CarCamera.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (car.transform.position.z >= -50)
        {
            GetComponent<Image>().color = Color.white;
            GetComponent<Image>().sprite = newSprite;
            tuto.text = "ESQUIVE!!! APPUI SUR ESPACE";
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerCamera.enabled = true;
            CarCamera.enabled = false;
            spawner.GetComponent<Spawner>().start = true;
            bill.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
