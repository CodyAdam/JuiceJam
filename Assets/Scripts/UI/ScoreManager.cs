using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public List<Tuple<string, float>> costsList = new List<Tuple<string, float>>();
    private float totalCost = 0;

    public GameObject moneyPrefab;
    private GameObject canvas;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
            Destroy(gameObject);
    }

    public void ResetScore()
    {
        costsList.Clear();
        totalCost = 0;
    }

    public static ScoreManager GetInstance()
    {
        return instance;
    }

    public void AddScore(string name, float cost)
    {
        if (canvas == null)
        {
            GetCanvas();
        }
        if (moneyPrefab != null && canvas != null)
        {
            GameObject money = Instantiate(moneyPrefab, canvas.transform);
            money.GetComponent<PopMoneyUI>().Init((int)cost);
        }
        costsList.Add(new Tuple<string, float>(name, cost));
        totalCost += cost;
    }

    public float GetTotalCost()
    {
        return totalCost;
    }

    public List<Tuple<string, float>> Get()
    {
        return costsList;
    }

    public void Reset()
    {
        costsList.Clear();
        totalCost = 0;
    }

    private void GetCanvas()
    {
        canvas = GameObject.Find("Canvas");
    }
}
