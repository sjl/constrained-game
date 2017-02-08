using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public Font pixelFont;

    void Start()
    {
    }

    void OnGUI()
    {
        GUI.skin.font = pixelFont;
        
        GUI.Label(new Rect(Screen.width / 2 - 40, 50, 80, 30), "MAIN MENU");

        if (GUI.Button(new Rect(Screen.width / 2 - 30, 240, 60, 30), "PLAY") || Input.GetKey("space"))
        {
            Application.LoadLevel(0);
        }
    }
}
