using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

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
            //Debug.Log("pressedLeft");
            // Reset String
            //livesCounter.text = "";
            // Change number
            //currentLife--;
            //score += currentLife;
            // livesCounter.text = score;
            currentLife--;
            pressedLeft = false;

        }
        //livesCounter.text = updatedScore;
        
        updatedScore = score + currentLife;
        livesCounter.text = updatedScore;
    }

    // Update is called once per frame
    void Update()
    {
        handleCounting();
        /*
        currentLife--;
        updatedScore = score + currentLife;
        livesCounter.text = updatedScore;
        */
    }
}
