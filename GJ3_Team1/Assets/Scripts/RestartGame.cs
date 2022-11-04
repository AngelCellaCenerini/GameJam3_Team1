using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{

    // Update is called once per frame
    public void changeScene()
    {
        // Restart Game
        SceneManager.LoadScene("TitleScene");
    }
}
