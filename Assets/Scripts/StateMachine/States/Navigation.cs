public class Navigation : State
{
    public int sessionTime;
    public int spawnETime;
    public Navigation(string name)
    {
        Name = name;
    }

    public override void Execute()
    {
        GetValues();
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.playingState);
        Game.singleton.m_StateMachine.RunState();
        
    }
    public void GetValues()
    {
        sessionTime = int.Parse(UIValues._valueSessonTime);
        spawnETime = int.Parse(UIValues._valueEnemyTime);
    }
}
