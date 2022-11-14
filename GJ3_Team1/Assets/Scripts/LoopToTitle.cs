using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoopToTitle : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        // Trigger Ending
        StartCoroutine(ExecuteAfterTime(5));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Trigger Victory Scene
        SceneManager.LoadScene("Title");

    }
}
