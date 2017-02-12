using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public Text timer;
    public Text score1;
    public Text score2;
    public Player player1;
    public Player player2;

    private float clock;

    void Start () {
        clock = 120.0f;
    }

    void Update () {
        clock -= Time.deltaTime;

        if (clock < 0.0f) {
            SceneManager.LoadScene("EndScreen");
            return;
        }

        int intClock = (int)clock;

        int minutes = intClock / 60;
        int seconds = intClock % 60;

        timer.text = System.String.Format("{0:d}:{1:d2}", minutes, seconds);
        score1.text = System.String.Format("{0:d}", player1.score);
        score2.text = System.String.Format("{0:d}", player2.score);
    }
}
