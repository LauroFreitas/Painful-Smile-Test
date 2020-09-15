public class GameOver : State
{
    public GameOver(string name)
    {
        Name = name;
    }

    public override void Execute()
    {
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.navegationState);
         
    }
}
