using System.Collections;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game singleton { get; private set; }
    public StateMachine m_StateMachine = new StateMachine();
    public Navigation navegationState;
    public Playing playingState;
    public Paused pausadState;
    public GameOver gameOverState;
    private void Awake()
    {
        if (singleton != this && singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        navegationState = new Navigation("Navegação");
        playingState = new Playing("Jogando");
        pausadState = new Paused("Pausado");
        gameOverState = new GameOver("GameOver");
        m_StateMachine.ChangeState(navegationState);

    }
    public void StartSpawn(int spawnTime)
    {
        StartCoroutine(Wait(spawnTime));
    }
    IEnumerator Wait(int spawnTime)
    {
        yield return new WaitForSeconds(0.1f);
        var e = FindObjectOfType<EnemiesSpawner>();
        e.StartCoroutine(spawnTime, 10);
    }
    public void GameOver() 
    {
        var enemiesSpawner = FindObjectOfType<EnemiesSpawner>();
        enemiesSpawner.StopAllCoroutines();

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            var e = enemies[i];
            Destroy(e);
        }

    }
}
