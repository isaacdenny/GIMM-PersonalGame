using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text waveText;
    [SerializeField] TMP_Text waveCountText;
    [SerializeField] Slider crystalHealthSlider;

    [SerializeField] Canvas loseScreenCanvas;
    [SerializeField] Canvas WinScreenCanvas;

    [HideInInspector]
    public Crystal crystal;

    private Canvas canvas;
    private WaveState waveState;
    internal bool isWave = false;


    void Start()
    {
        waveCountText.text = "Total Waves: " + GameManager.Instance.GetWaveCount();
        crystal = Crystal.Instance;
        canvas = GetComponent<Canvas>();
        waveState = (WaveState)GameManager.Instance.waveState;
    }


    void Update()
    {
        if (isWave)
        {
            canvas.enabled = true;

            UpdateTimer();

            scoreText.text = "Score: " + GameManager.Instance.GetScore();
            waveText.text = "Wave: " + GameManager.Instance.GetCurrentWave();
        }

        UpdateCrystalHealthSlider();
    }

    private void UpdateTimer()
    {
        int minuteValue = (int)(waveState.GetTimer() / 60f);
        int secondValue = Mathf.RoundToInt((waveState.GetTimer() % 60f));

        if (waveState.GetTimer() <= 60)
        {
            timerText.text = secondValue.ToString();
        }
        else
        {
            timerText.text = minuteValue + ":" + secondValue;
        }
    }

    private void UpdateCrystalHealthSlider()
    {
        if (crystal != null)
        {
            crystalHealthSlider.value = crystal.GetHealth() / 100f;
        }
    }

    private void InitLoseScreen()
    {
        canvas.enabled = false;
        loseScreenCanvas.enabled = true;
        Time.timeScale = 0f;
    }

    private void InitWinScreen()
    {
        canvas.enabled = false;
        WinScreenCanvas.enabled = true;
        Time.timeScale = 0f;
    }
}
