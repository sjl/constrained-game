using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public GameObject player;

    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Player>().Kill();
            SoundManager.FriendlyFire();
        } else if (collision.gameObject.tag == "Asteroid") {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Asteroid>().Explode();
        } else if (collision.gameObject.tag == "Bounds") {
            Destroy(gameObject);
        }
    }
}
