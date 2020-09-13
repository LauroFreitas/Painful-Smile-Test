using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playing : State
{
  
    public Playing(string name)
    {
        Name = name;
    }

    public override void Execute()
    {
        Time.timeScale = 1;
    }
    public void OnGameOver() 
    {
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.GameOverState);
    }
}
