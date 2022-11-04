using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LivesStringCounter : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI livesCounter;
    public string score;
    public string updatedScore;

    CharacterSwitch characterSwitch;
    public bool pressedLeft;
    private int currentLife = 9;

    void Awake()
    {
        // Handle Input Action
        characterSwitch = new CharacterSwitch();
        characterSwitch.SwitchMesh.SwitchLeft.performed += switchLeft;

        score = "x"; 
        updatedScore = score + currentLife;
        livesCounter.text = updatedScore;
    }

    public void switchLeft(InputAction.CallbackContext context)
    {
        pressedLeft = context.ReadValueAsButton();
    }

    public void handleCounting()
    {
        if (pressedLeft)
        {
            // Update Count
            currentLife--;
            pressedLeft = false;

            // Check if player looses
            if (currentLife < 1)
            {
                // Trigger Bad Ending
                SceneManager.LoadScene("BadEnding");
            }

        };

        // Update String
        updatedScore = score + currentLife;
        livesCounter.text = updatedScore;
    }

    // Update is called once per frame
    void Update()
    {
        handleCounting();
    }
}
