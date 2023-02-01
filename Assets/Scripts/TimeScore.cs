using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float score = 0;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            scoring();
            scoreText.text = score.ToString();
        }
    }

    void scoring()
    {
        score += 1;
        timer = 0;
    }
}   
