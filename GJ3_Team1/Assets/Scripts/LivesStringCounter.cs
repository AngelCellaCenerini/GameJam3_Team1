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
    private int currentLife = 9;

    // Check Skin Menu Input
    [SerializeField] private Button confirmButton = null;
    public ChangeCharacterUI characterChoice;
    // Check Obstacle Damage
    public ObstacleDamage obstacleDamage;

    void Awake()
    {

        score = "x"; 
        updatedScore = score + currentLife;
        livesCounter.text = updatedScore;

        // CONFIRM Button
        confirmButton.onClick.AddListener(handleCounting);
    }

    public void checkObstacleDamage()
    {
        if (obstacleDamage.isDamaged || characterChoice.choiceIsConfirmed)
        {
            handleCounting();
            obstacleDamage.isDamaged = false;
            characterChoice.choiceIsConfirmed = false;
        }
    }

    public void handleCounting()
    {
        // Update Count
        currentLife--;

        // Check if player looses
        if (currentLife < 1)
        {
            // Trigger Bad Ending
            SceneManager.LoadScene("BadEnding");
        }

        // Update String
        updatedScore = score + currentLife;
        livesCounter.text = updatedScore;
    }

    private void FixedUpdate()
    {
        checkObstacleDamage();
    }
}
