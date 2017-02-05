using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    public GameObject explosionPrefab;

    void Start () {
        StartCoroutine(DebugTest());
    }

    void Update () {
    }

    private IEnumerator DebugTest() {
        yield return new WaitForSeconds(4.0f);
        Explode();
    }

    // Destruction ------------------------------------------------------------
    private void SpawnChildren() {
        // TODO
    }

    private void SpawnExplosion() {
        GameObject explosion = Instantiate(explosionPrefab);
        explosion.transform.position = this.transform.position;
        Destroy(explosion, explosion.GetComponent<ParticleSystem>().duration);
    }

    private void Explode() {
        SpawnExplosion();
        SpawnChildren();
        Destroy(gameObject);
    }
}
