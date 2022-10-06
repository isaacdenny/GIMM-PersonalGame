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

    void Start()
    {
        waveCountText.text = "Total Waves: " + GameManager.Instance.GetWaveCount();
        crystal = Crystal.Instance;
        canvas = GetComponent<Canvas>();
        canvas.enabled = true;
    }
    void Update()
    {
        UpdateCrystalHealthSlider();
    }
    internal void UpdateWave(int wave) => waveText.text = "Wave: " + wave;
    internal void UpdateScore(int score) => scoreText.text = "Score: " + score;
    internal void UpdateTimer(float timer)
    {
        int minuteValue = (int)(timer / 60f);
        int secondValue = Mathf.RoundToInt((timer % 60f));

        if (timer <= 60)
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
        if (crystal == null) return;

        crystalHealthSlider.value = crystal.GetHealth() / 100f;
    }
    internal void InitLoseScreen()
    {
        canvas.enabled = false;
        loseScreenCanvas.enabled = true;
    }
    internal void InitWinScreen()
    {
        canvas.enabled = false;
        WinScreenCanvas.enabled = true;
    }
}
