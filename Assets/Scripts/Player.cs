using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    public int playerNumber = 1;

    public float thrust = 20.0f;
    public float torque = 2.0f;
    public float maxVelocity = 10.0f;

    public GameObject bulletPrefab;

    private Rigidbody2D physics;

    void Start () {
        physics = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
        if (InputThrust()) {
            if (physics.velocity.magnitude < maxVelocity) {
                physics.AddForce(
                    new Vector2(transform.up.x, transform.up.y) * thrust);
            }
        }

        if (InputRotate()) {
            float direction = (playerNumber == 1 ? 1.0f : -1.0f);
            physics.AddTorque(torque * direction);
        }
    }

    void Update () {
        if (InputShoot()) {
            Shoot();
        }
    }

    // Input ------------------------------------------------------------------
    private bool InputThrust() {
        if (playerNumber == 1) {
            return Input.GetKey(KeyCode.A);
        } else {
            return Input.GetKey(KeyCode.J);
        }
    }
    private bool InputRotate() {
        if (playerNumber == 1) {
            return Input.GetKey(KeyCode.S);
        } else {
            return Input.GetKey(KeyCode.K);
        }
    }
    private bool InputShoot() {
        if (playerNumber == 1) {
            return Input.GetKeyDown(KeyCode.D);
        } else {
            return Input.GetKeyDown(KeyCode.L);
        }
    }

    // Shooting ---------------------------------------------------------------
    private void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = this.transform.position + (this.transform.up * 0.5f);
        bullet.transform.up = this.transform.up;

        Rigidbody2D bulletPhysics = bullet.GetComponent<Rigidbody2D>();
        bulletPhysics.AddForce(this.transform.up * 100.0f);
    }
}
