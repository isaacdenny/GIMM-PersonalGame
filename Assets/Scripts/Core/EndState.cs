using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : State
{
    private UIManager uiManager;
    public override void Enter()
    {
        base.Enter();
        uiManager = GameManager.Instance.GetUIManager();
        InitEndPlay();
    }
    private void InitEndPlay()
    {
        Time.timeScale = 0f;
        uiManager.InitEndScreen();
    }

    public override void Exit()
    {
        uiManager.CloseEndScreen();
    }
}
