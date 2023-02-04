using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreContent : MonoBehaviour
{
    public TextMeshProUGUI labelsText;
    public TextMeshProUGUI costsText;
    void FixedUpdate()
    {
        string labels = "";
        string costs = "";
        List<Tuple<string, float>> costsList = ScoreManager.GetInstance().Get();
        foreach (Tuple<string, float> cost in costsList)
        {
            labels += cost.Item1 + "\n";
            costs += "$" + cost.Item2 + "\n";
        }
        labelsText.text = labels;
        costsText.text = costs;
    }
}