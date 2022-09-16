using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text waveText;
    [SerializeField] TMP_Text waveCountText;
    // Start is called before the first frame update
    void Start()
    {
        waveCountText.text = "Total Waves: " + GameManager.Instance.GetWaveCount();
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

        if (GameManager.Instance.GetTimer() <= 60)
        {
            timerText.text = secondValue.ToString();
        }
        else
        {
            timerText.text = minuteValue + ":" + secondValue;
        }

        waveText.text = "Wave: " + GameManager.Instance.GetCurrentWave();
    }
}
