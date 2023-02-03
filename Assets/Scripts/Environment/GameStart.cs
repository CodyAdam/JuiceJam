using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public GameObject spawner;
    public GameObject car;
    public Sprite newSprite;
    public Image bill;
    public TextMeshProUGUI tuto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(car.transform.position.z >= -50 )
        {
            GetComponent<Image>().color = Color.white;
            GetComponent<Image>().sprite = newSprite;
            tuto.text = "ESQUIVE!!! APPUI SUR ESPACE";
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            spawner.GetComponent<Spawner>().start = true;
            bill.color = Color.white;
        }
    }
}
