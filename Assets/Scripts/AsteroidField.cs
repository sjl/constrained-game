using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidField : MonoBehaviour {
    public GameObject asteroidPrefab;

    public float density = 0.02f;
    public float densityScale = 1.1f;

    public static int asteroidCount = 0;
    public float asteroidSpeedMin = 100.0f;
    public float asteroidSpeedMax = 300.0f;

    void Start () {
        PopulateField(density);
    }

    void Update () {
        if (asteroidCount == 0) {
            PopulateField(density);
            density *= densityScale;
        }
    }

    private void PopulateField(float density) {
        for (float x = -12.0f; x <= 12.0f; x += 1.0f) {
            for (float y = -10.0f; y <= 10.0f; y += 1.0f) {
                if (Random.Range(0.0f, 1.0f) < density) {
                    Spawn(x, y);
                }
            }
        }
    }

    private void Spawn(float x, float y) {
        GameObject asteroid = Instantiate(asteroidPrefab);
        Rigidbody2D physics = asteroid.GetComponent<Rigidbody2D>();

        Vector3 location = new Vector2(x, y) + (Random.insideUnitCircle * 1.0f);
        asteroid.transform.position = new Vector3(location.x, location.y, 0.0f);

        Vector2 direction = (Random.insideUnitCircle *
                             Random.Range(asteroidSpeedMin, asteroidSpeedMax));
        physics.AddForce(direction);

        asteroidCount += 1;
    }

}
