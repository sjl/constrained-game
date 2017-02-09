using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    public int playerNumber = 1;

    public float thrust = 20.0f;
    public float torque = 2.0f;
    public float maxVelocity = 10.0f;
    private bool inputEnabled = true;
    private bool invincible = false;

    private int invincibleLayer;
    private int normalLayer;

    private float bulletSpeed = 350.0f;

    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public GameObject engine;
    public GameObject rotator;
    public GameObject smoke;

    private ParticleSystem smokeParticles;
    private ParticleSystem engineParticles;
    private ParticleSystem rotatorParticles;
    private Rigidbody2D physics;
    private Animator animator;

    private static int AnimatorInvincible = Animator.StringToHash("Invincible");

    void Start () {
        physics = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        smokeParticles = smoke.GetComponent<ParticleSystem>();
        engineParticles = engine.GetComponent<ParticleSystem>();
        rotatorParticles = rotator.GetComponent<ParticleSystem>();

        invincibleLayer = LayerMask.NameToLayer("Invincible");
        normalLayer = LayerMask.NameToLayer("Gravity");

        Spawn();
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

        if (InputThrust()) {
            engineParticles.Play();
        } else {
            engineParticles.Stop();
        }

        if (InputRotate()) {
            rotatorParticles.Play();
        } else {
            rotatorParticles.Stop();
        }
    }

    // Input ------------------------------------------------------------------
    private bool InputThrust() {
        if (playerNumber == 1) {
            return inputEnabled && Input.GetKey(KeyCode.S);
        } else {
            return inputEnabled && Input.GetKey(KeyCode.K);
        }
    }
    private bool InputRotate() {
        if (playerNumber == 1) {
            return inputEnabled && Input.GetKey(KeyCode.A);
        } else {
            return inputEnabled && Input.GetKey(KeyCode.L);
        }
    }
    private bool InputShoot() {
        if (playerNumber == 1) {
            return inputEnabled && Input.GetKeyDown(KeyCode.D);
        } else {
            return inputEnabled && Input.GetKeyDown(KeyCode.J);
        }
    }

    // Shooting ---------------------------------------------------------------
    private void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = this.transform.position + (this.transform.up * 0.6f);
        bullet.transform.up = this.transform.up;

        Rigidbody2D bulletPhysics = bullet.GetComponent<Rigidbody2D>();
        bulletPhysics.AddForce(this.transform.up * bulletSpeed);

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.player = gameObject;

        SoundManager.Shoot(playerNumber);
    }

    // Respawning -------------------------------------------------------------
    public void Kill() {
        if (!invincible) {
            SpawnExplosion();
            SoundManager.PlayerDeath();
            StartCoroutine(Spawn());
            Spawn();
        }
    }

    private void SpawnExplosion() {
        GameObject explosion = Instantiate(explosionPrefab);
        explosion.transform.position = this.transform.position;
        Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.duration);
    }

    private Vector3 StartPosition() {
        if (playerNumber == 1) {
            return new Vector3(-8.0f, 0.0f, -1.0f);
        } else {
            return new Vector3(8.0f, 0.0f, -1.0f);
        }
    }
    private Vector3 HiddenPosition() {
        if (playerNumber == 1) {
            return new Vector3(-800.0f, 0.0f, 0.0f);
        } else {
            return new Vector3(800.0f, 0.0f, 0.0f);
        }
    }
    private void HideShip() {
        transform.position = HiddenPosition();
    }
    private void ResetShip() {
        // Zero out the physics stuff so we don't move a bit after respawn.
        physics.velocity = Vector2.zero;
        physics.angularVelocity = 0.0f;

        // And move back to the origin.
        transform.position = StartPosition();
        transform.eulerAngles = Vector3.zero;
        transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    }
    private IEnumerator Spawn() {
        inputEnabled = false;
        HideShip();

        Vector3 messagePoint = StartPosition() + new Vector3(-0.25f, 0.25f, 0.0f);

        MessageManager.ShowMessage("3", messagePoint);
        yield return new WaitForSeconds(1.2f);
        MessageManager.ShowMessage("2", messagePoint);
        yield return new WaitForSeconds(1.2f);
        MessageManager.ShowMessage("1", messagePoint);
        yield return new WaitForSeconds(1.2f);

        inputEnabled = true;
        ResetShip();

        var tween = new GoTweenConfig();
        tween.easeType = GoEaseType.BounceOut;
        tween.onComplete(SpawnComplete);
        Go.to(transform, 1.0f, tween.scale(1.0f));

        StartCoroutine(ApplyInvincibility());
    }
    private void SpawnComplete(AbstractGoTween tween) {
        smokeParticles.Play();
    }

    // Invincibility ----------------------------------------------------------
    private IEnumerator ApplyInvincibility() {
        gameObject.layer = invincibleLayer;
        invincible = true;
        animator.SetBool(AnimatorInvincible, true);

        yield return new WaitForSeconds(2.0f);

        animator.SetBool(AnimatorInvincible, false);
        invincible = false;
        gameObject.layer = normalLayer;
    }
}
