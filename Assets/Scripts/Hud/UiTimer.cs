using UnityEngine;
using UnityEngine.UI;

public class UiTimer : MonoBehaviour
{
    public Text timerText;
    public GameObject GameOverImage;
    [SerializeField] public float time { get; private set;}
    public float timeInput;
    
    private void Start()
    {
        timeInput = Game.singleton.navegationState.sessionTime;
        time = timeInput;
    }
     
    public void FixedUpdate()
    {
        Decrease();
        timerText.text = time.ToString(format:"00");
    }

    private void Decrease() 
    {
        time -= 1f * Time.deltaTime;
        if (time <= 0) 
        {
            GameOver();
        }
    }

    public void GameOver() 
    {
        time = timeInput;
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.gameOverState);
        Game.singleton.m_StateMachine.RunState();
        Game.singleton.GameOver();
        Time.timeScale = 0;
        GameOverImage.SetActive(true);
    }
}
