using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public float beforeStart = 2f;
    public AudioClip readyGo;
    public AudioSource soundSource;
    // Start is called before the first frame update
    void Start()
    {
        soundSource.clip = readyGo;
        soundSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (beforeStart > 0)
        {
            beforeStart -= Time.deltaTime;
        }

        else
        {
            beforeStart = 0;
            BeginGame();
        }
    }

    void BeginGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
