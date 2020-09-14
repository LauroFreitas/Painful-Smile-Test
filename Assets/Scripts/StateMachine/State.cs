using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public string Name { get; set; }
    
    public virtual void Execute()
    {
        Game.singleton.m_StateMachine.RunState();
    }
}