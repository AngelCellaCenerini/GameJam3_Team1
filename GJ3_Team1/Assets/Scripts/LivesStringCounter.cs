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
    public SwitchCharacter characterChoice;
    // Check Obstacle Damage
    public ObstacleDamage obstacleDamage;
    // Check DropOff Damage
    public CheckPointRespawn dropOffDamage;

    public bool isChanged = false;

    void Awake()
    {

        score = "x"; 
        updatedScore = score + currentLife;
        livesCounter.text = updatedScore;
    }

    public void checkObstacleDamage()
    {
        if (obstacleDamage.isDamaged || characterChoice.choiceIsConfirmed || dropOffDamage.lifeIsLost)
        {
            handleCounting();
            // Reset 
            obstacleDamage.isDamaged = false;
            characterChoice.choiceIsConfirmed = false;
            dropOffDamage.lifeIsLost = false;
            // Respawn
            isChanged = true;
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
