using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject LoseScreen;
    public GameObject WinScreen;
    public GameObject AudioManager;
    public ParticleSystem ParticleSystem;
    public Material PlatformMaterial;
    public Material PlayerMaterial;
    public Controls Controls;
    public Slider Slider;
    public enum State
    {
        Playing,
        Won,
        Loss,
    }

    public  void Awake()
    {
        PlayerMaterial.SetFloat("_Dissole_Amount",0);
    }
    IEnumerator Dissolve()
    {
        float dissolve = 0;
        while (dissolve <1)
        {
            PlayerMaterial.SetFloat("_Dissole_Amount", dissolve);
            dissolve += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        
    }
   
    public State CurrentState { get; private set; }
    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Loss;
        Controls.enabled = false;
        StartCoroutine(Dissolve());
        Invoke("ScreenOfLose", 1f);
        Debug.Log("Game Over");
    }

    private void ScreenOfLose()
    {
        LoseScreen.SetActive(true);
        AudioManager.SetActive(false);
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        Controls.enabled = false;
        LevelIndex++;
        Invoke("ScreenOfWin", 0.5f);
        Debug.Log("You Won!!");
    }

    private void ScreenOfWin()
    {
        WinScreen.SetActive(true);
        AudioManager.SetActive(false);
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
