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

    // Start is called before the first frame update
    void Start()
    {
        waveCountText.text = "Total Waves: " + GameManager.Instance.GetWaveCount();
        crystal = Crystal.Instance;
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.GameState gameState = GameManager.Instance.GetGameState();

        if (gameState == GameManager.GameState.Playing)
        {
            canvas.enabled = true;

            UpdateTimer();
            UpdateCrystalHealthSlider();

            scoreText.text = "Score: " + GameManager.Instance.GetScore();
            waveText.text = "Wave: " + GameManager.Instance.GetCurrentWave();
        }
        else if (gameState == GameManager.GameState.Lose)
        {
            InitLoseScreen();
        }
        else if (gameState == GameManager.GameState.Win)
        {
            InitWinScreen();
        }
    }

    private void UpdateTimer()
    {
        int minuteValue = (int)(GameManager.Instance.GetTimer() / 60f);
        int secondValue = Mathf.RoundToInt((GameManager.Instance.GetTimer() % 60f));

        if (GameManager.Instance.GetTimer() <= 60)
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
