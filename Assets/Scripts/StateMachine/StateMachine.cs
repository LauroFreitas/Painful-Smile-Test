using UnityEngine;

public class StateMachine
{
    private State currentState;
    private State previousState;
    public void RunState()
    {
        if(currentState != null)
        {
            currentState.Execute();
        }
    }

    public void ChangeState(State newState)
    {
        if (newState == currentState)
        {
            return;
        }
            
        else
        {
            previousState = currentState;
            
            if(previousState != null)
            Debug.Log(newState.Name);
            currentState = newState;
        }
    }

}
