using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoopToTitle : MonoBehaviour
{
    public Image image;

    void Start()
    {
        image = GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 0.0f;
        image.color = tempColor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Trigger Ending
        // StartCoroutine(ExecuteAfterTime(5));
        handleFadeOut();
    }

    void handleFadeOut()
    {
        var tempColor = image.color;
        if (tempColor.a <= 255f)
        {
            tempColor.a = tempColor.a + 0.01f;
            image.color = tempColor;
            StartCoroutine(ExecuteAfterTime(5));
        }
        
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Trigger Victory Scene
        SceneManager.LoadScene("Title");

    }
}
