using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    // Check Player Character
    public CharacterSwitcher characterScript;

    private float forceApplied = 2.0f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check Player's Skin & Abilities
        if (characterScript.thirdSkin)
        {
            // Get Obstacle's Rigidbody
            Rigidbody obstacleBody = hit.collider.attachedRigidbody;

            // Check if null
            if (obstacleBody != null)
            {
                // Direct Force
                Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
                // Remove Y coordinate
                //forceDirection.y = 0;
                // Normalize Force Vector
                forceDirection.Normalize();
                // Apply Force
                obstacleBody.AddForceAtPosition(forceDirection * forceApplied, transform.position, ForceMode.Impulse);
            }
        }
    }
}
