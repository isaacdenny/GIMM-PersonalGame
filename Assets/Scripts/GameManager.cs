using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] List<GameObject> dontDestroyList = new();
    private bool levelComplete;
    private bool waveComplete;
    private int score = 0;
    private int currentWave = 0;
    [SerializeField] float timeToWin = 60f;
    [SerializeField] int waveCount = 3;
    [SerializeField] private float gameTimer = 0f;
    private bool gameTimerRunning = false;

    public static GameManager Instance { get; private set; }
    public enum GameState { Win, Lose, Playing, InMenu}
    private GameState gameState;

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
        gameState = GameState.Playing;
    }

    private void Start()
    {
        InitWaveTimer();
    }

    void Update()
    {
        CheckForWin();

        if (gameState == GameState.Lose || gameState == GameState.Win)
        {
            levelComplete = true;
            Time.timeScale = 0f;
        }
    }

    private void CheckForWin()
    {
        if (!gameTimerRunning) return;

        if (gameTimer <= 0f && !levelComplete && currentWave >= waveCount)
        {
            SetGameState(GameState.Win);
            return;
        }
        else if (gameTimer <= 0f && !levelComplete && currentWave < waveCount)
        {
            gameTimerRunning = false;
        }
        gameTimer -= Time.deltaTime;
    }
    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }
    public void SubtractFromScore(int scoreValue)
    {
        score -= scoreValue;
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
    public void StartNextWave()
    {
        if (gameTimerRunning) return;
        currentWave++;
        InitWaveTimer();
        gameTimerRunning = true;
        waveComplete = false;
    }

    private void InitWaveTimer()
    {
        gameTimer = timeToWin;
    }

    internal int GetScore()
    {
        return score;
    }
    internal float GetTimer()
    {
        return gameTimer;
    }
    internal bool GetLevelStatus()
    {
        return levelComplete;
    }
    internal bool GetWaveStatus()
    {
        return waveComplete;
    }
    internal bool GetTimerStatus()
    {
        return gameTimerRunning;
    }
    internal int GetCurrentWave()
    {
        return currentWave;
    }
    internal int GetWaveCount()
    {
        return waveCount;
    }
    internal void SetGameState(GameState newState)
    {
        if (newState != gameState)
        {
            gameState = newState;
        }
    }
    internal GameState GetGameState()
    {
        return gameState;
    }
}
