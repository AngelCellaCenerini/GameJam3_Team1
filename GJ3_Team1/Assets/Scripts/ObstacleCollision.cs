using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    // Check Player Character
    public SwitchCharacter characterScript;
    public GameObject yellowCat;
    Animator animator;

    private float forceApplied = 2.0f;
    public bool obstacleIsHit;
    bool pushPressed = false;
    bool hasExited = false;

    private void Awake()
    {
        animator = yellowCat.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (pushPressed)
        {
            if (!hasExited)
            {
                // Trigger Cat Animation
                animator.SetBool("isPushing", true);
            }
        }
        else
        {
            // Trigger Cat Animation
            animator.SetBool("isPushing", false);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check Collided Body
        if (hit.gameObject.tag == "ToPush")
        {
            // Check Player's Skin & Abilities
            if (characterScript.thirdSkin)
            {
                // Get Obstacle's Rigidbody
                Rigidbody obstacleBody = hit.collider.attachedRigidbody;

                // Check if null
                if (obstacleBody != null)
                {
                    pushPressed = true;  
                    // Direct Force
                    Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
                    // Remove Y coordinate
                    //forceDirection.y = 0;
                    // Normalize Force Vector
                    forceDirection.Normalize();
                    // Apply Force
                    obstacleBody.AddForceAtPosition(forceDirection * forceApplied, transform.position, ForceMode.Impulse);
                }
                else
                {
                    pushPressed = false;
                }
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PushTrigger")
        {
            pushPressed = false;
            hasExited = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AnimStop")
        {
            //pushPressed = false;
            //hasExited = true;
        }

        if (other.gameObject.tag == "PushTrigger")
        {
            if (hasExited)
            {
                pushPressed = false;
                hasExited = false;
            }
            //pushPressed = false;
            //hasExited = true;
        }
    }
}
