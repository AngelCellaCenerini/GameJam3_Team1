using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimMovementController : MonoBehaviour
{
    // Reference
    PlayerInput playerInput;
    CharacterController characterController;
    Animator animator;
    Animator animatorB;
    Animator animatorY;
    Animator animatorW;

    // Cats
    public GameObject blackCat;
    public GameObject whiteCat;
    public GameObject yellowCat;

    int isWalkingHash;
    int isRunningHash;

    // Movement
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunMovement;
    // States
    bool isMovementPressed;
    bool isRunPressed;
    bool isJumpPressed = false;
    bool isJumping = false;
    // Multipliers
    float runMultiplier = 3.0f;
    float rotationFractorPerFrame = 1.0f;
    float initialJumpVelocity;
    float maxJumpHeight = 1.0f;
    float maxJumpTime = 0.5f;
    // Gravity
    float groundedGravity = -.05f;
    float gravity = -9.18f;
    // Rotation
    float rotationFactorPerFrame = 15.0f;

    // Player Character
    // public CharacterSwitcher characterScript;
    public SwitchCharacter characterScript;

    void Awake()
    {
        // Reference
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();
        
        // Characte Animators
        animatorB = blackCat.GetComponent<Animator>();
        animatorW = whiteCat.GetComponent<Animator>();
        animatorY = yellowCat.GetComponent<Animator>();
        animator = animatorB;

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");

        // Register Input & Cancel Movement
        // Walk
        playerInput.CharacterControls.Move.performed += onMovementInput;
        playerInput.CharacterControls.Move.canceled += onMovementInput;
        // Run
        playerInput.CharacterControls.Run.performed += onRun;
        playerInput.CharacterControls.Run.canceled += onRun;
        // Jump
        playerInput.CharacterControls.Jump.started += onJump;
        playerInput.CharacterControls.Jump.canceled += onJump;

        setJumpVariables();

    }

    void handleRotation()
    {
        // Update Character Orientation
        Vector3 positionToLookAt;
        // Position Character should point to
        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;
        // Current Character Rotation
        Quaternion currentRotation = transform.rotation;

        // Check if Character is moving 
        if (isMovementPressed)
        {
            // New Rotation based on updated position
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }
        
    }

    void onMovementInput(InputAction.CallbackContext context)
    {
        // Manage Call back functions
        // Walk
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = -currentMovementInput.x;
        currentMovement.z = -currentMovementInput.y;
        // Run
        currentRunMovement.x = -currentMovementInput.x * runMultiplier;
        currentRunMovement.z = -currentMovementInput.y * runMultiplier;
        // Check if moving
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    void onRun(InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();
    }

    void onJump(InputAction.CallbackContext context)
    {
        isJumpPressed = context.ReadValueAsButton();
    }

    void setJumpVariables()
    {
        // Calculate Gravity
        float timeToApex = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }

    void handleJump()
    {
        // Check Player's Skin
        if (characterScript.secondSkin)
        {
            // Check if jumping
            if (!isJumping && characterController.isGrounded && isJumpPressed)
            {
                // Jump
                isJumping = true;
                currentMovement.y = initialJumpVelocity;
                currentRunMovement.y = initialJumpVelocity;
            }
            else if (!isJumpPressed && isJumping && characterController.isGrounded)
            {
                // Restore State
                isJumping = false;
            }
        }
    }

    void handleAnimation() {

        // Check Current Character
        if (characterScript.firstSkin)
        {
            // White Cat
            animator = animatorW;
        }
        else if (characterScript.secondSkin)
        {
            // Black Cat
            animator = animatorB;
        }
        else if (characterScript.thirdSkin)
        {
            // Yellow Cat
            animator = animatorY;
        }


        // WALK ANIMATION
        // Animate
        if (isMovementPressed)
        {
            // Walk
            animator.SetBool("isWalking", true);
        }
        else if (!isMovementPressed)
        {
            // Stop Walking
            animator.SetBool("isWalking", false);
        }
        // DEATH ANIMATION
        if (isMovementPressed)
        {
            // Walk
            animator.SetBool("isWalking", true);
        }
        else if (!isMovementPressed)
        {
            // Stop Walking
            animator.SetBool("isWalking", false);
        }
        // JUMP ANIMATION
        if (isJumpPressed && !isJumping)
        {
            // Walk
            animator.SetBool("isJumping", true);
        }
        else if (!isJumpPressed && isJumping)
        {
            // Walk
            animator.SetBool("isJumping", false);
        }


        // Manage Animation Switches
        //bool isWalking = animator.GetBool(isWalkingHash);
        //bool isRunning = animator.GetBool(isRunningHash);

        /*
        // Animate
        if (isMovementPressed && !isWalking)
        {
            // Walk
            animator.SetBool("isWalking", true);
        }
        else if (!isMovementPressed && isWalking)
        {
            // Stop Walking
            animator.SetBool("isWalking", false);
        }

        if ((isMovementPressed && isRunPressed) && !isRunning)
        {
            // Run
            animator.SetBool("isRunning", true);
        }
        else if ((!isMovementPressed || isRunPressed) && isRunning)
        {
            // Stop Running
            animator.SetBool("isRunning", false);
        }
        */
    }

    void handleGravity()
    {
        if (characterController.isGrounded)
        {
            // Apply Downwards Force (Gravity)
            currentMovement.y = groundedGravity;
            currentRunMovement.y = groundedGravity;
        }
        else
        {
            currentMovement.y += gravity * Time.deltaTime;
            currentRunMovement.y += gravity * Time.deltaTime;
        }
    }


    void FixedUpdate()
    {
        // Move
        // Check if running
        if (isRunPressed)
        {
            characterController.Move(currentRunMovement * Time.deltaTime);
        }
        else
        {
            characterController.Move(currentMovement * Time.deltaTime * 1.6f);
        }

        // Animate
        handleAnimation();
        // Update Direction
        // handleRotation();

        handleGravity();
        handleJump();
        handleRotation();
    }

    void OnEnable()
    {
        // Enable Input System (Action Map)
        playerInput.CharacterControls.Enable();
    }
    void OnDisable()
    {
        // Disable Input System (Action Map)
        playerInput.CharacterControls.Disable();
    }
}
