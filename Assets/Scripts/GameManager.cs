using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score = 0;

    [SerializeField] List<GameObject> dontDestroyList = new();
    private bool levelComplete;

    public static GameManager instance { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null && instance != this)
        {
            Destroy(instance);
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        foreach (GameObject go in dontDestroyList)
        {
            DontDestroyOnLoad(go);
        }

        levelComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void SubtractFromScore(int scoreValue)
    {
        score -= scoreValue;
    }

    internal int GetScore()
    {
        return score;
    }

    public void LoadNextLevel()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        while (!operation.isDone)
        {
            float progress = operation.progress;
            Debug.Log("progress");
        }
    }

    internal void WinLevel()
    {
        levelComplete = true;
        LoadNextLevel();
    }
}
