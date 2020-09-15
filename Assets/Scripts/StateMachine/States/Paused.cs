using UnityEngine;

public class Paused : State
{
    public Paused(string name)
    {
        Name = name;
    }

    public override void Execute()
    {
        base.Execute();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Game.singleton.m_StateMachine.ChangeState(Game.singleton.playingState);
        }
    }
}
