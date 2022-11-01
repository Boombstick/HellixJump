using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScore : MonoBehaviour
{
    public Text Text;
    public Player Player;

    private void Update()
    {
        Text.text = "Passed Platforms: " + Player.PlatformScore.ToString();

    }

}
