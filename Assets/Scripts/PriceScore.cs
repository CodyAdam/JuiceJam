using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PriceScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeScore;
    public TextMeshProUGUI crashScore;
    public TextMeshProUGUI JumpScore;
    public float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        score = timeScore.GetComponent<TimeScore>().score + crashScore.GetComponent<JumpScore>().score + JumpScore.GetComponent<JumpScore>().score;
        scoreText.text = (score).ToString();
    }
}
