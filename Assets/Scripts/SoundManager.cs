using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager instance;

    public GameObject fieldCleared;
    public GameObject friendlyFire;
    public GameObject playerShoot1;
    public GameObject playerShoot2;
    public GameObject playerDeath;
    public GameObject asteroidDeath;
    public GameObject streak10;
    public GameObject streak20;

    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(this);
        } else if (this != instance) {
            Destroy(this.gameObject);
        }
    }
    void Update() {
    }

    public static void FieldCleared() {
        instance.fieldCleared.GetComponent<AudioSource>().Play();
    }
    public static void FriendlyFire() {
        instance.friendlyFire.GetComponent<AudioSource>().Play();
    }
    public static void Shoot(int player) {
        if (player == 1) {
            instance.playerShoot1.GetComponent<AudioSource>().Play();
        } else {
            instance.playerShoot2.GetComponent<AudioSource>().Play();
        }
    }
    public static void PlayerDeath() {
        instance.playerDeath.GetComponent<AudioSource>().Play();
    }
    public static void AsteroidDeath() {
        instance.asteroidDeath.GetComponent<AudioSource>().Play();
    }
    public static void Streak10() {
        instance.streak20.GetComponent<AudioSource>().Play();
    }
    public static void Streak20() {
        instance.streak10.GetComponent<AudioSource>().Play();
    }
}
