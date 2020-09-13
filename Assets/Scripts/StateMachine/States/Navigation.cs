using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Navigation : State
{
    Button play;
    public Navigation(string name)
    {
        Name = name;
    }

    public override void Execute()
    {
        if (!play)
        { 
        }
        else
        {
            base.Execute();
            play = GameObject.FindGameObjectWithTag("Play").GetComponent<Button>();
            play.onClick = new Button.ButtonClickedEvent();
            play.onClick.AddListener(() => Play());
        }
    }
    public void Play() 
    {
        SceneManager.LoadScene("Game");
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoJogando);
    }
}
