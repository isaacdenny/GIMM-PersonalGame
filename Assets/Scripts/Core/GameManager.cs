using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : StateMachine
{

    [SerializeField] List<GameObject> dontDestroyList = new();

    [SerializeField] int waveCount = 3;

    private bool levelComplete;
    private bool waveComplete;
    private int score = 0;
    private int currentWave = 0;

    public static GameManager Instance { get; private set; }

    public State playing, lose, win, inMenu;

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
    }

    private void Start()
    {
    }

    void Update()
    {
        StateUpdate();
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
 

    internal int GetScore()
    {
        return score;
    }

    internal bool GetLevelStatus()
    {
        return levelComplete;
    }
    internal bool GetWaveStatus()
    {
        return waveComplete;
    }

    internal int GetCurrentWave()
    {
        return currentWave;
    }
    internal int GetWaveCount()
    {
        return waveCount;
    }
}
