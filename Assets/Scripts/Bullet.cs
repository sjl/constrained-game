using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public GameObject player;

    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            MessageManager.ShowMessage("FRIENDLY FIRE!",
                new Vector3(
                    Mathf.Clamp(transform.position.x - 0.5f, -12.0f, 3.0f),
                    transform.position.y + 1.0f,
                    0.0f));
            Destroy(gameObject);
            collision.gameObject.GetComponent<Player>().Kill();
            SoundManager.FriendlyFire();
        } else if (collision.gameObject.tag == "Asteroid") {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Asteroid>().Explode();

            Player p = player.GetComponent<Player>();

            p.streak += 1;
            if (p.streak == 10) {
                SoundManager.Streak10();
                MessageManager.ShowMessage("10 IN A ROW", player.transform.position);
            } else if (p.streak == 20) {
                SoundManager.Streak20();
                MessageManager.ShowMessage("20 IN A ROW", player.transform.position);
            }
        } else if (collision.gameObject.tag == "Bounds") {
            Destroy(gameObject);
        }
    }
}
