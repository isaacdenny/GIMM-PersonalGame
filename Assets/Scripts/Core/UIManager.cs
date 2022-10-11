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

    [SerializeField] Canvas mainUICanvas;
    [SerializeField] Canvas winScreenCanvas;
    [SerializeField] Canvas loseScreenCanvas;

    [HideInInspector]
    public Crystal crystal;

    public static UIManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }
    }
    void Start()
    {
        waveCountText.text = "Total Waves: " + GameManager.Instance.GetWaveCount();
        crystal = Crystal.Instance;
        mainUICanvas.enabled = true;
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
        mainUICanvas.enabled = false;
        loseScreenCanvas.enabled = true;
    }
    internal void InitWinScreen()
    {
        mainUICanvas.enabled = false;
        winScreenCanvas.enabled = true;
    }

    internal void CloseLoseScreen()
    {
        mainUICanvas.enabled = true;
        loseScreenCanvas.enabled = false;
    }

    internal void CloseWinScreen()
    {
        mainUICanvas.enabled = true;
        winScreenCanvas.enabled = false;
    }
}
