using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchCharacter : MonoBehaviour
{
    CharacterSwitch characterSwitch;
    bool pressedOne;
    bool pressedTwo;
    bool pressedThree;

    // Characters
    public GameObject blackCat;
    public GameObject whiteCat;
    public GameObject yellowCat;

    // Character Animators
    Animator animatorW;
    Animator animatorB;
    Animator animatorY;

    // Skills Icons
    public GameObject climbSkillIcon;
    public GameObject jumpSkillIcon;
    public GameObject pushSkillIcon;


    // Skin Menu & Skins
    public GameObject skinMenu;
    public bool firstSkin = true;
    public bool secondSkin = false;
    public bool thirdSkin = false;

    // Confirmation Reference
    public bool choiceIsConfirmed = false;
    public bool isConfirmed = false;

    // SFXs
    public AudioSource audio;
    public AudioClip catDeath;

    void Awake()
    {
        // Handle Input Action
        characterSwitch = new CharacterSwitch();
        characterSwitch.SwitchMesh.ChooseWC.performed += switchToWhite;
        characterSwitch.SwitchMesh.ChooseBC.performed += switchToBlack;
        characterSwitch.SwitchMesh.ChooseYC.performed += switchToYellow;

        // States
        firstSkin = true;
        secondSkin = false;
        thirdSkin = false;

        // Character Animators
        animatorW = whiteCat.GetComponent<Animator>();
        animatorB = blackCat.GetComponent<Animator>();
        animatorY = yellowCat.GetComponent<Animator>();

        // Skills Icons
        climbSkillIcon.SetActive(true);
        jumpSkillIcon.SetActive(false);
        pushSkillIcon.SetActive(false);

        // Audio Resource
        audio = GetComponent<AudioSource>();
    }

    public void switchToWhite(InputAction.CallbackContext context)
    {
        // Check if Skin Menu Open
        if (skinMenu.activeSelf)
        {
            pressedOne = context.ReadValueAsButton();
        }
    }
    public void switchToBlack(InputAction.CallbackContext context)
    {
        // Check if Skin Menu Open
        if (skinMenu.activeSelf)
        {
            pressedTwo = context.ReadValueAsButton();
        }
    }
    public void switchToYellow(InputAction.CallbackContext context)
    {
        // Check if Skin Menu Open
        if (skinMenu.activeSelf)
        {
            pressedThree = context.ReadValueAsButton();
        }
    }

    public void handleSwitch()
    {
        // Check if Skin Menu is active
        if (skinMenu.activeSelf)
        {
            // Switch to Character 1
            if (pressedOne && !whiteCat.activeSelf)
            {
                // Confirm Character Choice
                choiceIsConfirmed = true;
                isConfirmed = true;
                // Play SFX
                playSFX();
                // Close Menu
                skinMenu.SetActive(false);

                if (blackCat.activeSelf)
                {
                    // Trigger Death Animation
                    animatorB.SetBool("isDying", true);  
                }
                else if (yellowCat.activeSelf)
                {
                    // Trigger Death Animation
                    animatorY.SetBool("isDying", true);
                }

                // Reset Input
                pressedOne = false;
                // Trigger Switch
                StartCoroutine(ChangeToWhite(3));
            }

            // Switch to Character 2
            else if (pressedTwo && !blackCat.activeSelf)
            {
                // Confirm Character Choice
                choiceIsConfirmed = true;
                isConfirmed = true;
                // Play SFX
                playSFX();
                // Close Menu
                skinMenu.SetActive(false);

                if (whiteCat.activeSelf)
                {
                    // Trigger Death Animation
                    animatorW.SetBool("isDying", true);
                    
                }
                else if (yellowCat.activeSelf)
                {
                    // Trigger Death Animation
                    animatorY.SetBool("isDying", true);
                }

                // Reset Input
                pressedTwo = false;
                // Trigger Switch
                StartCoroutine(ChangeToBlack(3));
            }

            // Switch to Character 3
            else if (pressedThree && !yellowCat.activeSelf)
            {
                // Confirm Character Choice
                choiceIsConfirmed = true;
                isConfirmed = true;
                // Play SFX
                playSFX();
                // Close Menu
                skinMenu.SetActive(false);

                if (whiteCat.activeSelf)
                {
                    // Trigger Death Animation
                    animatorW.SetBool("isDying", true);
                }
                else if (blackCat.activeSelf)
                {
                    // Trigger Death Animation
                    animatorB.SetBool("isDying", true);
                }

                // Reset Input
                pressedThree = false;
                // Trigger Switch
                StartCoroutine(ChangeToYellow(3)); 
            }

        }
    }

    IEnumerator ChangeToWhite(float time1)
    {
        yield return new WaitForSeconds(time1);

        // Change Character
        blackCat.SetActive(false);
        whiteCat.SetActive(true);
        yellowCat.SetActive(false);

        // Update Character Status
        firstSkin = true;
        secondSkin = false;
        thirdSkin = false;
    }
    IEnumerator ChangeToBlack(float time2)
    {
        yield return new WaitForSeconds(time2);

        // Change Character
        blackCat.SetActive(true);
        whiteCat.SetActive(false);
        yellowCat.SetActive(false);

        // Update Character Status
        firstSkin = false;
        secondSkin = true;
        thirdSkin = false;

    }
    IEnumerator ChangeToYellow(float time3)
    {
        yield return new WaitForSeconds(time3);

        // Change Character
        blackCat.SetActive(false);
        whiteCat.SetActive(false);
        yellowCat.SetActive(true);

        // Update Character Status
        firstSkin = false;
        secondSkin = false;
        thirdSkin = true;

    }

    void handleIcons()
    {
        if (firstSkin)
        {
            // Skills Icons
            climbSkillIcon.SetActive(true);
            jumpSkillIcon.SetActive(false);
            pushSkillIcon.SetActive(false);
        }
        else if (secondSkin)
        {
            // Skills Icons
            climbSkillIcon.SetActive(false);
            jumpSkillIcon.SetActive(true);
            pushSkillIcon.SetActive(false);
        }
        else if (thirdSkin)
        {
            // Skills Icons
            climbSkillIcon.SetActive(false);
            jumpSkillIcon.SetActive(false);
            pushSkillIcon.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Handle Keyboard Input
        handleSwitch();
        // Update UI
        handleIcons();
    }

    void playSFX()
    {
        audio.clip = catDeath;
        audio.Play();
    }

    void OnEnable()
    {
        // Enable Input System (Action Map)
        characterSwitch.SwitchMesh.Enable();
    }
    void OnDisable()
    {
        // Disable Input System (Action Map)
        characterSwitch.SwitchMesh.Disable();
    }
}
