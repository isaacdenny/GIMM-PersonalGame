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

    public Crystal crystal;
    // Start is called before the first frame update
    void Start()
    {
        waveCountText.text = "Total Waves: " + GameManager.Instance.GetWaveCount();
        crystal = Crystal.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        UpdateCrystalHealthSlider();

        scoreText.text = "Score: " + GameManager.Instance.GetScore();
        waveText.text = "Wave: " + GameManager.Instance.GetCurrentWave();
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
            Debug.Log(crystal.GetHealth());
            crystalHealthSlider.value = crystal.GetHealth() / 100f;
        }
    }
}
