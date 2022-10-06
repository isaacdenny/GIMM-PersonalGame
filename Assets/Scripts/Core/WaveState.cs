using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveState : State
{
    [SerializeField] private EnemySpawner enemySpawner;

    [SerializeField] float timeToWin = 60f;
    [SerializeField] private float gameTimer = 0f;

    private bool waveTimerRunning = false;
    private UIManager uiManager;

    public override void Enter()
    {
        base.Enter();
        InitWave();
    }
    public override void Do()
    {
        EvaluateWaveStatus();
    }
    public override void Exit()
    {
        base.Exit();
        waveTimerRunning = false;
        uiManager.isWave = false;
        enemySpawner.isWave = false;
    }
    private void EvaluateWaveStatus()
    {
        if (!waveTimerRunning) return;

        gameTimer -= Time.deltaTime;
        uiManager.UpdateTimer(gameTimer);

        if (Crystal.Instance.GetHealth() <= 0f)
        {
            complete = true;
            return;
        }
        else if (gameTimer <= 0f)
        {
            complete = true;
            return;
        }

    }
    private void InitWave()
    {
        uiManager = GameManager.Instance.GetUIManager();
        GameManager.Instance.SetCurrentWave();
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
