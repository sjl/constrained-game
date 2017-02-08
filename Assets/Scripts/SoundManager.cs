using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager instance;

    public GameObject fieldCleared;
    public GameObject friendlyFire;

    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(this);
        } else if (this != instance) {
            Destroy(this.gameObject);
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            FieldCleared();
        }
    }

    public static void FieldCleared() {
        instance.fieldCleared.GetComponent<AudioSource>().Play();
    }
    public static void FriendlyFire() {
        instance.friendlyFire.GetComponent<AudioSource>().Play();
    }
}
