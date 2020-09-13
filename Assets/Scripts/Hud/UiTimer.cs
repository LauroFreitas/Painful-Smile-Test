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
        timeInput = float.Parse(UIValues._valueSessonTime);
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
            time = timeInput;
            Game.singleton.estadoJogando.OnGameOver();
        }
    }
}
