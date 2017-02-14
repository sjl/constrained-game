using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButton(0) || Input.GetMouseButton(1)) { }
		else if(Input.anyKey)
        {
            SceneManager.LoadScene("Game");
        }
	}
}
