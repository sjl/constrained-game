using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour {
    public static MessageManager instance;

    public GameObject letterPrefab;
    public float letterWidth = 0.6f;

    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(this);
        } else if (this != instance) {
            Destroy(this.gameObject);
        }

        Go.defaultEaseType = GoEaseType.SineInOut;
    }

    public static void ShowMessage(string message, Vector3 location) {
        float x = location.x;
        float delay = 0.0f;

        // for (int i = message.Length - 1; i >= 0; i--) {
        for (int i = 0; i < message.Length; i++) {
            char c = message[i];
            GameObject letter = Instantiate(instance.letterPrefab);
            TextMesh tm = letter.GetComponent<TextMesh>();
            tm.text = c.ToString();
            tm.color = Color.HSVToRGB(Random.Range(0.0f, 0.3f), 1.0f, 1.0f);

            TweenLetter(letter, new Vector3(x, location.y, -1.0f), delay);

            x += instance.letterWidth;
            delay += 0.1f;
            Destroy(letter, 5.0f);
        }
    }

    private static void TweenLetter(GameObject letter, Vector3 location, float initialDelay) {
        float x = location.x;
        float y = location.y;
        float z = location.z;

        Vector3 start = new Vector3(-15.0f, y + Random.Range(-2.0f, 2.0f), z);
        Vector3 end   = new Vector3( 15.0f, y + Random.Range(-2.0f, 2.0f), z);

        letter.transform.position = start;

        var tweenIn = new GoTween(letter.transform, 0.5f,
                                  new GoTweenConfig().position(location));

        var tweenOut = new GoTween(letter.transform, 0.5f,
                                  new GoTweenConfig().position(end));

        var chain = new GoTweenChain();
        chain.appendDelay(initialDelay)
             .append(tweenIn)
             .appendDelay(1.0f)
             .append(tweenOut);
        chain.play();
    }
}
