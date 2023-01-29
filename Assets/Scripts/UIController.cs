using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    float score = 0;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Points : " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1){
            scoring();
            scoreText.text = "Points : " + score.ToString();
        }
    }

    void scoring()
    {
        score += 1;
        timer = 0;
    }
}
