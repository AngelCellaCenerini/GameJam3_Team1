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
    private Animator platformAnimator2;

    public GameObject platform;
    public GameObject platform2;

    void Awake()
    {
        // References
        playerInput = new PlayerInput();
        platformAnimator = platform.GetComponent<Animator>();
        platformAnimator2 = platform2.GetComponent<Animator>();
        // Climb
        playerInput.CharacterControls.Climb.performed += onClimb;
    }

    public void onClimb(InputAction.CallbackContext context)
    {
        isClimbing = context.ReadValueAsButton();
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
        platformAnimator2.SetBool("isClimbing", false);


    }
}
