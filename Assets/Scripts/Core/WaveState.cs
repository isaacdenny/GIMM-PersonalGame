using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveState : State
{
    [SerializeField] private EnemySpawner enemySpawner;

    [SerializeField] float timeToWin = 60f;
    [SerializeField] private float gameTimer = 0f;

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
        enemySpawner.isWave = false;
    }
    private void EvaluateWaveStatus()
    {
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
        gameTimer = timeToWin;
        enemySpawner.isWave = true;
    }
    internal float GetTimer()
    {
        return gameTimer;
    }
}
