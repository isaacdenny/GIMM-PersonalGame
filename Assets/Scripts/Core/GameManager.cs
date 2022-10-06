using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : StateMachine
{

    [SerializeField] List<GameObject> dontDestroyList = new();
    [SerializeField] int waveCount = 3;
    [SerializeField] private UIManager uiManager;
    public static GameManager Instance { get; private set; }
    public State waveState, prepState, loseState, winState, inMenuState;

    private bool levelComplete;
    private bool waveComplete;
    private int score = 0;
    private int currentWave = 0;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null && Instance != this)
        {
            Destroy(Instance);
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);

        foreach (GameObject go in dontDestroyList)
        {
            DontDestroyOnLoad(go);
        }

        levelComplete = false;
        Set(prepState);
    }

    void Update()
    {
        StateUpdate();
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
        uiManager.UpdateScore(score);
    }
    public void SubtractFromScore(int scoreValue)
    {
        score -= scoreValue;
        uiManager.UpdateScore(score);
    }
    public void LoadNextLevel()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        while (!operation.isDone)
        {
            float progress = operation.progress;
            Debug.Log(progress);
        }
    }
    public override void SetNextState()
    {
        if (state == waveState && Crystal.Instance.GetHealth() > 0f)
        {
            Set(prepState);
        }
        else if (state == waveState && Crystal.Instance.GetHealth() <= 0f)
        {
            Set(loseState);
        }
        else if (state == prepState && currentWave < waveCount)
        {
            currentWave++;
            Set(waveState);
        }
        else if (state == prepState && currentWave == waveCount)
        {
            Set(winState);
        }
    }
    internal int GetScore() => score;
    internal bool GetLevelStatus() => levelComplete;
    internal bool GetWaveStatus() => waveComplete;
    internal int GetCurrentWave() => currentWave;
    internal int GetWaveCount() => waveCount;
    internal UIManager GetUIManager() => uiManager;
}
