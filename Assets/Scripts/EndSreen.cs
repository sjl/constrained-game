using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSreen: MonoBehaviour
{

    int score = 0;
    public Font pixelFont;

    void Start()
    {
        //score = PlayerPrefs.GetInt("Score");
    }

    void OnGUI()
    {
        GUI.skin.font = pixelFont;

        //Add win condition
        if (true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 60, 50, 120, 30), "SUCCESS");
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, 50, 100, 30), "MISSION FAILED");
        }

        GUI.Label(new Rect(Screen.width / 2 - 70, 100, 140, 30), "Score: " + score);
        if (GUI.Button(new Rect(Screen.width / 2 - 150, 200, 300, 30), "BACK TO MAIN MENU"))
        {
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, 240, 100, 30), "RETRY") || Input.GetKey("space"))
        {
            Time.timeScale = 1.0f;
            Application.LoadLevel(0);
        }
    }
}
