using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] List<GameObject> dontDestroyList = new();
    private bool levelComplete;
    private int score = 0;
    [SerializeField] float timeToWin = 60f;
    [SerializeField] private float gameTimer = 0f;

    public static GameManager Instance { get; private set; }

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
        gameTimer = timeToWin;
    }
    void Update()
    {
        CheckForWin();
    }

    private void CheckForWin()
    {
        if (gameTimer <= 0f && !levelComplete)
        {
            Time.timeScale = 0f;
            WinLevel();
            return;
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

    internal void WinLevel()
    {
        levelComplete = true;
        InitWinScreen();
    }

    internal void LoseLevel()
    {
        levelComplete = true;
        InitLoseScreen();
    }

    private void InitLoseScreen()
    {
        Debug.Log("LoseScreenNotImplemented");
    }

    private void InitWinScreen()
    {
        Debug.Log("WinScreenNotImplemented");
    }
    internal int GetScore()
    {
        return score;
    }
    internal float GetTimer()
    {
        return gameTimer;
    }
}
