using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveState : State
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private EnemySpawner enemySpawner;

    [SerializeField] float timeToWin = 60f;
    [SerializeField] private float gameTimer = 0f;

    private bool waveTimerRunning = false;

    public override void Enter()
    {
        base.Enter();
        InitWave();
    }
    public override void Do()
    {
        CheckForWin();
    }

    public override void Exit()
    {
        base.Exit();
        waveTimerRunning = false;
        uiManager.isWave = false;
        enemySpawner.isWave = false;
    }
    private void CheckForWin()
    {
        if (!waveTimerRunning) return;

        gameTimer -= Time.deltaTime;

        if (gameTimer <= 0f)
        {
            complete = true;
            return;
        }
        else if (Crystal.Instance.GetHealth() <= 0f)
        {
            complete = true;
            return;
        }

    }

    private void InitWave()
    {
        gameTimer = timeToWin;
        waveTimerRunning = true;
        uiManager.isWave = true;
        enemySpawner.isWave = true;
    }
    internal float GetTimer()
    {
        return gameTimer;
    }
    internal bool GetTimerStatus()
    {
        return waveTimerRunning;
    }
}
