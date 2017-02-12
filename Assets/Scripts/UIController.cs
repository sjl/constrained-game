using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    public void mainMenuPressed()
    {
        SceneManager.LoadScene(2);
    }

    public void retryPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void playPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void exitPressed()
    {
        Application.Quit();
    }

	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
