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
        SceneManager.LoadScene(0);
    }

    public void retryPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void playPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void creditsPressed()
    {
        SceneManager.LoadScene(3);
    }

    public void exitPressed()
    {
        Application.Quit();
    }

	// Use this for initialization
	void Start () {
        Score1.text = "" + PlayerPrefs.GetInt("score1");
        Score2.text = "" + PlayerPrefs.GetInt("score2");
	}
	
	// Update is called once per frame
	void Update () {

	}
}
