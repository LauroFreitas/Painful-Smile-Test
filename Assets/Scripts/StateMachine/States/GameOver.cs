using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : State
{
    public GameOver(string name)
    {
        Name = name;
    }

    public override void Execute()
    {
        GameObject gameOverView = GameObject.Find("GameOverView");
        gameOverView.SetActive(true);
        gameOverView.transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 0;
        Game.singleton.GameOver();
    }
  
}
