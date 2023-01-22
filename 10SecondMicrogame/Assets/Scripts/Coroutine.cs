using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coroutine : MonoBehaviour
{
    public void Death()
{
    //Start the coroutine we define below named ChangeAfter2SecondsCoroutine().
    StartCoroutine(ChangeScene());
}

IEnumerator ChangeScene()
{
    //Print the time of when the function is first called.
    Debug.Log("Started Coroutine at timestamp : " + Time.time);

    //yield on a new YieldInstruction that waits for however many seconds.
    yield return new WaitForSeconds(3);

    //After we have waited 2 seconds print the time again.
    Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    //And load the scene
    SceneManager.LoadScene("GameOverLose");
}
}
