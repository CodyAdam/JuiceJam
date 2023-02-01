using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TOTALScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI priceScore;
    public float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = (priceScore.GetComponent<PriceScore>().score * 0.8).ToString();
    }
}
