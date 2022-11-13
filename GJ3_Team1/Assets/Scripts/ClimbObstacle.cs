using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbObstacle : MonoBehaviour
{

    public SwitchCharacter characterScript;

    // White Cat 
    public GameObject whiteCat;
    Animator catAnimator;

    private Animator platformAnimator;
    private Animator platformAnimator2;

    public GameObject platform;
    public GameObject platform2;

    void Awake()
    {
        platformAnimator = platform.GetComponent<Animator>();
        platformAnimator2 = platform2.GetComponent<Animator>();
        catAnimator = whiteCat.GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ToClimb")
        {  
            // Check Player Skin
            if (characterScript.firstSkin)
            {
                // Move Platform
                platformAnimator.SetBool("isClimbing", true);
                platformAnimator2.SetBool("isClimbing", true);
                // Start Climbing Animation
                catAnimator.SetBool("isClimbing", true);

                // Trigger Ending
                StartCoroutine(ExecuteAfterTime(1.5f));

            }
            
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Reset Animation
        platformAnimator.SetBool("isClimbing", false);
        platformAnimator2.SetBool("isClimbing", false);
        // Stop Climbing Animation
        catAnimator.SetBool("isClimbing", false);


    }
}
