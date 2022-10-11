using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : State
{
    private UIManager uiManager;
    public override void Enter()
    {
        base.Enter();
        uiManager = GameManager.Instance.GetUIManager();
        InitWinLevel();
    }
    private void InitWinLevel()
    {
        Time.timeScale = 0f;
        uiManager.InitWinScreen();
    }

    public override void Exit()
    {
        uiManager.CloseWinScreen();
    }
}
