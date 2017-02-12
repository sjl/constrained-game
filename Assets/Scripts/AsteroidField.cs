using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidField : MonoBehaviour {
    public GameObject asteroidPrefab;

    public int asteroidSpawnAmount = 0;

    public static int asteroidCount = 0;
    public float asteroidSpeedMin = 100.0f;
    public float asteroidSpeedMax = 300.0f;

    void Start () {
        PopulateField(asteroidSpawnAmount);
    }

    void Update () {
        if (asteroidCount == 0) {
            SceneManager.LoadScene("EndScreen");
        }
    }

    private void PopulateField(int amount) {
        for (int i = 0; i < amount; i++) {
            Spawn(Random.Range(-13.0f, 13.0f),
                  Random.Range(-10.0f, 10.0f));
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
