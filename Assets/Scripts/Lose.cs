﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour {

    // Use this for initialization
    void Start () {

        if (PlayerPrefs.GetInt("success") == 0)
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
