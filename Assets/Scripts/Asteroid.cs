﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    public GameObject explosionPrefab;
    public GameObject childPrefab;
    public int pointValue;

    void Start () {
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.X)) {
            Explode();
        }
    }

    // Destruction ------------------------------------------------------------
    private void SpawnChildren() {
        if (childPrefab != null) {
            int count = Random.Range(2, 4);
            for (int i = 0; i < count; i++) {
                SpawnChild();
            }
        }
    }
    private void SpawnChild() {
        GameObject child = Instantiate(childPrefab);
        Rigidbody2D physics = child.GetComponent<Rigidbody2D>();

        Vector3 location = Random.insideUnitCircle * 1.0f;
        child.transform.position = transform.position + location;

        Vector2 direction = Random.insideUnitCircle * 200.0f;
        physics.AddForce(direction);
        AsteroidField.asteroidCount += 1;
    }
    private void SpawnExplosion() {
        GameObject explosion = Instantiate(explosionPrefab);
        explosion.transform.position = this.transform.position;
        Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.duration);
    }

    public void Explode() {
        SoundManager.AsteroidDeath();
        SpawnExplosion();
        SpawnChildren();
        Destroy(gameObject);
        AsteroidField.asteroidCount -= 1;
    }

    // Collision --------------------------------------------------------------
    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            Explode();
            collision.gameObject.GetComponent<Player>().Kill();
            if (Random.Range(0.0f, 1.0f) < 0.02f) {
                SoundManager.WatchOut();
            }
        }
    }
}
