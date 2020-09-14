using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : State
{
    public GameOver(string name)
    {
        Name = name;
    }

    public override void Execute()
    {
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoNavegacao);
         
    }
}
