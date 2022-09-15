using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;

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

    //load levels
    //keeping track of score


}
