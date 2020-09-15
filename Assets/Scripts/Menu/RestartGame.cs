using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartGame : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.playingState);
        Game.singleton.m_StateMachine.RunState();
        var uiPoints = FindObjectOfType<UiPoints>();
        uiPoints.ResetPoints();
    }
    public void Play()
    {
        Game.singleton.m_StateMachine.RunState();
        Time.timeScale = 1;
    }

    public void Menu()
    {
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.navegationState);
        SceneManager.LoadScene("Menu");
        var uiPoints = FindObjectOfType<UiPoints>();
        uiPoints.ResetPoints();
    }
}
