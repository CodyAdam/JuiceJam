using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    public TextMeshProUGUI totalText;

    // Update is called once per frame
    void FixedUpdate()
    {
        totalText.text = "$" + ScoreManager.GetInstance().GetTotalCost().ToString();
    }
}
