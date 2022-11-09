using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void changeScene()
    {
        // Restart Game
        SceneManager.LoadScene("GameScene");
    }
}
