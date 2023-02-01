using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JumpScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        }
}

