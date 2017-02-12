using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager instance;

    public AudioSource fieldCleared;
    public AudioSource friendlyFire;
    public AudioSource playerShoot1;
    public AudioSource playerShoot2;
    public AudioSource playerDeath;
    public AudioSource asteroidDeath;
    public AudioSource streak10;
    public AudioSource streak20;
    public AudioSource watchOut;

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
        instance.fieldCleared.Play();
    }
    public static void FriendlyFire() {
        instance.friendlyFire.Play();
    }
    public static void Shoot(int player) {
        if (player == 1) {
            instance.playerShoot1.Play();
        } else {
            instance.playerShoot2.Play();
        }
    }
    public static void PlayerDeath() {
        instance.playerDeath.Play();
    }
    public static void AsteroidDeath() {
        instance.asteroidDeath.Play();
    }
    public static void Streak10() {
        instance.streak20.Play();
    }
    public static void Streak20() {
        instance.streak10.Play();
    }
    public static void WatchOut() {
        instance.watchOut.Play();
    }
}
