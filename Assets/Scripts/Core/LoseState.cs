using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : State
{
    private UIManager uiManager;
    public override void Enter()
    {
        base.Enter();
        uiManager = GameManager.Instance.GetUIManager();
        InitLoseLevel();
    }

    private void InitLoseLevel()
    {
        Time.timeScale = 0f;
        uiManager.InitLoseScreen();
    }
}
