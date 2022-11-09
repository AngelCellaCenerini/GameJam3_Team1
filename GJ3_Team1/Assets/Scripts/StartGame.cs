using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void playGame()
    {
        // Trigger Victory Scene
        SceneManager.LoadScene("GameScene");
    }
}
