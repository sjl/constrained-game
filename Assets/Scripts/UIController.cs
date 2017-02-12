using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text Score1;
    public Text Score2;

    public void mainMenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void retryPressed()
    {
        SceneManager.LoadScene("Game");
    }

    public void playPressed()
    {
        SceneManager.LoadScene("Game");
    }

    public void creditsPressed()
    {
        SceneManager.LoadScene("Credits");
    }

    public void exitPressed()
    {
        Application.Quit();
    }

	// Use this for initialization
	void Start () {
        if (Score1 != null) {
            Score1.text = "" + PlayerPrefs.GetInt("score1");
        }
        if (Score2 != null) {
            Score2.text = "" + PlayerPrefs.GetInt("score2");
        }
	}
	
	// Update is called once per frame
	void Update () {

	}
}
