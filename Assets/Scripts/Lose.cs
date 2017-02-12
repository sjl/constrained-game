using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour {

    public int win = PlayerPrefs.GetInt("success");
    public int player1 = PlayerPrefs.GetInt("score1");
    public int player2 = PlayerPrefs.GetInt("score2");

    // Use this for initialization
    void Start () {
        if(win == 0)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("space") || Input.GetKey("r"))
        {
            SceneManager.LoadScene(0);
        }
        else if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
