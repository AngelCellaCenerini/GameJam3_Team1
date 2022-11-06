using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{

    public MeshRenderer player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FinalDestination")
        {
            // Destroy Player
            player.enabled = false;

            // Trigger Ending
            StartCoroutine(ExecuteAfterTime(2));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Trigger Victory Scene
        SceneManager.LoadScene("Victory");
        
    }
}
