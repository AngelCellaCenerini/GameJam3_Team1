using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClimbObstacle : MonoBehaviour
{
    PlayerInput playerInput;

    public CharacterSwitcher characterScript;

    bool isClimbing = false;
    private Animator platformAnimator;

    public GameObject platform;

    void Awake()
    {
        // References
        playerInput = new PlayerInput();
        platformAnimator = platform.GetComponent<Animator>();
        // Climb
        playerInput.CharacterControls.Climb.performed += onClimb;
    }

    public void onClimb(InputAction.CallbackContext context)
    {
        isClimbing = context.ReadValueAsButton();
    }

    void FixedUpdate()
    {
        if (platformAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            // Debug.Log("Animation over");
        }
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

                // Trigger Ending
                StartCoroutine(ExecuteAfterTime(2));

            }
            
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Reset Animation
        platformAnimator.SetBool("isClimbing", false);


    }
}
