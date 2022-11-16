using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinGame : MonoBehaviour
{

    // public MeshRenderer player;
    // public Image image;
    [SerializeField] private Image fadeOut;
    [SerializeField] private Color fadeAlpha;
    Color tempColor;

    bool isTriggered;

    private void Start()
    {
        fadeAlpha.a = 0;
        fadeOut.color = fadeAlpha;

       isTriggered = false;
    }

    private void FixedUpdate()
    {
        if (isTriggered)
        {
            // Fade Fading
            handleFadeOut();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FinalDestination")
        {
            // Start Fading
            isTriggered = true;
        }
    }
    void handleFadeOut()
    {

        if (fadeAlpha.a <= 255)
        {
            fadeAlpha.a = fadeAlpha.a + 0.007f;
            fadeOut.color = fadeAlpha;

            // Trigger Ending
            StartCoroutine(ExecuteAfterTime(5.5f));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Trigger Victory Scene
        SceneManager.LoadScene("Title");

    }
}
