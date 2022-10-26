using UnityEngine;
using UnityEngine.UI;

public class LevelNumberPassed : MonoBehaviour
{
    public Text Text;
    public Game Game;


    private void Start()
    {

        Text.text = "Level "  + (Game.LevelIndex).ToString() + " Passed";
    }
}
