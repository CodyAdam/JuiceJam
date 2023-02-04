using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class RetryButton : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log(" Retry button clicked");
        ScoreManager.GetInstance().Reset();
        SceneManager.LoadScene("MainScene");
    }
}