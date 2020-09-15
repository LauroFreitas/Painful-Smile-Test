public class Playing : State
{
    public Playing(string name)
    {
        Name = name;
    }

    public override void Execute()
    {
        Game.singleton.StartSpawn(Game.singleton.navegationState.spawnETime);
    }
   
}
