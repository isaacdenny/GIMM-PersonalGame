using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : StateMachine
{

    [SerializeField] List<GameObject> dontDestroyList = new();
    [SerializeField] private UIManager uiManager;
    public static GameManager Instance { get; private set; }
    public State waveState, prepState, endState;

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
            Destroy(Instance.gameObject);
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);

        foreach (GameObject go in dontDestroyList)
        {
            DontDestroyOnLoad(go);
        }
    }

    private void Start()
    {
        InitLevel();
    }

    private void InitLevel()
    {
        Set(prepState);
        Time.timeScale = 1.0f;
        score = 0;
        currentWave = 0;
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

        //while (!operation.isDone)
        //{
        //    float progress = operation.progress;
        //    Debug.Log(progress);
        //}
        InitLevel();
    }
    public void ReloadLevel()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        //while (!operation.isDone)
        //{
        //    float progress = operation.progress;
        //    Debug.Log(progress);
        //}
        InitLevel();
    }
    public override void SetNextState()
    {
        float crystalHealthThisFrame = Crystal.Instance.GetHealth();

        if (state == waveState && crystalHealthThisFrame > 0f)
        {
            Set(prepState);
        }
        else if (state == waveState && crystalHealthThisFrame <= 0f)
        {
            Set(endState);
        }
        else if (state == prepState)
        {
            SetCurrentWave();
            Set(waveState);
        }
        
    }
    internal int GetScore() => score;
    internal bool GetWaveStatus() => waveComplete;
    internal int GetCurrentWave() => currentWave;
    internal void SetCurrentWave()
    {
        currentWave ++;
        uiManager.UpdateWave(currentWave);
    }
    internal UIManager GetUIManager() => uiManager;

    internal void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
