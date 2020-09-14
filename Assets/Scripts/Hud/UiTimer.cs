using System.Collections;
using System.Collections.Generic;
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
        timeInput = Game.singleton.estadoNavegacao.sessionTime;
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
        Vector3 respawnPoint = new Vector3(0, 0, 0);
        Transform player = FindObjectOfType<PlayerMovement>().transform;
        player.position = respawnPoint;
        GameOverImage.SetActive(true);
        time = timeInput;
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.GameOverState);
        Game.singleton.m_StateMachine.RunState();
        Game.singleton.GameOver();
        Time.timeScale = 0;
    }
}
