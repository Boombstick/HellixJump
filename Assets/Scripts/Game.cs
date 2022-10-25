using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject LoseScreen;
    public GameObject WinScreen;
    public Controls Controls;
    public enum State
    {
        Playing,
        Won,
        Loss,
    }



   
    public State CurrentState { get; private set; }
    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Loss;
        Controls.enabled = false;
        LoseScreen.SetActive(true);
        Debug.Log("Game Over");
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;
        
        CurrentState = State.Won;
        Controls.enabled = false;
        LevelIndex++;
        WinScreen.SetActive(true);
        Debug.Log("You Won!!");   
    }
    
    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string LevelIndexKey = "LevelIndex";

    public void Reloadlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
