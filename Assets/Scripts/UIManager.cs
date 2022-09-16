using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        int minuteValue = (int)(GameManager.Instance.GetTimer() / 60f);
        int secondValue = Mathf.RoundToInt((GameManager.Instance.GetTimer() % 60f));

        scoreText.text = "Score: " + GameManager.Instance.GetScore();

        //if (GameManager.Instance.GetTimer() <= 0) return;

        if (GameManager.Instance.GetTimer() <= 60)
        {
            timerText.text = secondValue.ToString();
        }
        else
        {
            timerText.text = minuteValue + ":" + secondValue;
        }

    }
}
