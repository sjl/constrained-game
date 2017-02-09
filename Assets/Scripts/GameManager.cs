using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text timer;

    private float clock;

    void Start () {
        clock = 120.0f;
    }

    void Update () {
        clock -= Time.deltaTime;

        if (clock < 0.0f) {
            // TODO: Game Over
            return;
        }

        int intClock = (int)clock;

        int minutes = intClock / 60;
        int seconds = intClock % 60;

        timer.text = System.String.Format("{0:d}:{1:d}", minutes, seconds);
    }
}
