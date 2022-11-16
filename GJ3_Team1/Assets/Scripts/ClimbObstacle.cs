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

    private Animator newAnimator1;
    private Animator newAnimator2;
    private Animator newAnimator3;

    public GameObject platform;
    public GameObject platform2;

    public GameObject newPlatform1;
    public GameObject newPlatform2;
    public GameObject newPlatform3;

    // Camera
    public GameObject cameraAngle;
    Animator animator;

    void Awake()
    {
        platformAnimator = platform.GetComponent<Animator>();
        platformAnimator2 = platform2.GetComponent<Animator>();
        newAnimator1 = newPlatform1.GetComponent<Animator>();
        newAnimator2 = newPlatform2.GetComponent<Animator>();
        newAnimator3 = newPlatform3.GetComponent<Animator>();
        catAnimator = whiteCat.GetComponent<Animator>();

        // Reference Camera Animator
        animator = cameraAngle.GetComponent<Animator>();

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
                newAnimator1.SetBool("isClimbing", true);
                newAnimator2.SetBool("isClimbing", true);
                // Start Climbing Animation
                catAnimator.SetBool("isClimbing", true);

                // Trigger Ending
                StartCoroutine(ExecuteAfterTime(2f));
                
                /*
                if (other.gameObject.tag == "FinalLadder")
                {
                    newAnimator3.SetBool("isClimbing", true);
                    // Start Climbing Animation
                    catAnimator.SetBool("isClimbing", true);
                    StartCoroutine(finalAnim(5f));
                }
                */

            }

        }

        if (other.gameObject.tag == "FinalLadder")
        {
            if (characterScript.firstSkin)
            {
                newAnimator3.SetBool("isClimbing", true);
                // Start Climbing Animation
                catAnimator.SetBool("isClimbing", true);
                StartCoroutine(finalAnim(4f));

                // Change Camera
                animator.SetBool("fourthFloor", true);
            }
            
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Reset Animation
        platformAnimator.SetBool("isClimbing", false);
        platformAnimator2.SetBool("isClimbing", false);
        newAnimator1.SetBool("isClimbing", false);
        newAnimator2.SetBool("isClimbing", false);
        // Stop Climbing Animation
        catAnimator.SetBool("isClimbing", false);


    }

    IEnumerator finalAnim(float time)
    {
        yield return new WaitForSeconds(time);

        newAnimator3.SetBool("isClimbing", false);
        // Stop Climbing Animation
        catAnimator.SetBool("isClimbing", false);
    }
}
