using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Game : MonoBehaviour
{

    public int EnemiesValue;
    public static Game singleton { get; private set; }
    public StateMachine m_StateMachine = new StateMachine();
    //public GameObject canvasMenu;
    private Button restartButton;
    private Button backtoMenuButton;
    public Navigation estadoNavegacao;
    public Playing estadoJogando;
    public Paused estadoPausado;
    public GameOver GameOverState;
    private GameObject spawner;
    public GameObject canvas;
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

        estadoNavegacao = new Navigation("Navegação");
        estadoJogando = new Playing("Jogando");
        estadoPausado = new Paused("Pausado");
        GameOverState = new GameOver("GameOver");
        m_StateMachine.ChangeState(estadoNavegacao);
    }
    void Update()
    {
        m_StateMachine.RunState();
    }

    public void GameOver()
    {
        StopSpawner();

        //ACHA O BOTÃO DE RESTART
        restartButton = GameObject.FindGameObjectWithTag("Restart").GetComponent<Button>();
        restartButton.onClick = new Button.ButtonClickedEvent();
        restartButton.onClick.AddListener(() => OnRestart());

        //ACHA O BOTÃO DE MENU
        backtoMenuButton = GameObject.FindGameObjectWithTag("Menu").GetComponent<Button>();
        backtoMenuButton.onClick = new Button.ButtonClickedEvent();
        backtoMenuButton.onClick.AddListener(() => OnBackToMenu());

        //LIMPA OS INIMIGOS
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            var e = enemies[i];
            Destroy(e);
        }
    }
    public void OnRestart()
    {
        m_StateMachine.ChangeState(estadoJogando);
        GameObject gameOverView = GameObject.Find("GameOverView");
        gameOverView.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void OnPlay()
    {
        m_StateMachine.ChangeState(estadoJogando);
        canvas.SetActive(false);
        StartCoro();
    }

    public void OnBackToMenu()
    {
        canvas.SetActive(true);
        m_StateMachine.ChangeState(estadoNavegacao);
        GameObject gameOverView = GameObject.Find("GameOverView");
        gameOverView.transform.GetChild(0).gameObject.SetActive(false);
        SceneManager.LoadScene("Menu");
    }
    public void StopSpawner()
    {
        spawner = GameObject.Find("EnemiesSpawner");
        spawner.GetComponent<EnemiesSpawner>().StopInstantiate();
    }
    public void SpawnerRestart()
    {
        spawner = GameObject.Find("EnemiesSpawner");
        spawner.GetComponent<EnemiesSpawner>().RestartInstantiate();
    }
    public void StartCoro()
    {
        StartCoroutine(BooWaitChangeScene());
    }
    public IEnumerator BooWaitChangeScene()
    {
        while (true)
        {
            if (GameObject.Find("EnemiesSpawner") == null)
            {
                yield return false;
            }
            else
            {
                yield return true;
                StopCoroutine(BooWaitChangeScene());
                Debug.Log("AAA");
                SpawnerRestart();

                break;
            }
        }
    }
}
