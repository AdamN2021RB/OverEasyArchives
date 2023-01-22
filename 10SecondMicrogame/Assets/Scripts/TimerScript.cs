using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public float timerClock = 10f;
    public Text timeText;

    // Update is called once per frame
    void Update()
    {
        timeText.text = (timerClock).ToString("0");
        if (timerClock > 0)
        {
            timerClock -= Time.deltaTime;
        }

        else
        {
            timerClock = 0;
            Debug.Log("lose game");
            SceneManager.LoadScene("GameOverLose");
        }

    }

}
