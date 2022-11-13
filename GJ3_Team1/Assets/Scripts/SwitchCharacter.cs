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
    //public GameObject yellowCat;

    // Character Animators
    Animator animatorW;
    Animator animatorB;
    Animator animatorY;


    // Skin Menu & Skins
    public GameObject skinMenu;
    public bool firstSkin = false;
    public bool secondSkin = true;
    public bool thirdSkin = false;

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
        //animatorY = yellowCat.GetComponent<Animator>();
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
                if (blackCat.activeSelf)
                {
                    // Trigger Death Animation
                    animatorB.SetBool("isDying", true);
                    pressedOne = false;
                    // Trigger Switch
                    StartCoroutine(ChangeToWhite(2));
                }
                /*
                else if (yellowCat.activeSelf)
                {
                    // Trigger Death Animation
                    animatorY.SetBool("isDying", true);
                }
                */
            }
            // Switch to Character 2
            else if (pressedTwo && !blackCat.activeSelf)
            {
                Debug.Log("switchB");
                if (whiteCat.activeSelf)
                {
                    // Trigger Death Animation
                    animatorW.SetBool("isDying", true);
                    // Trigger Switch
                    StartCoroutine(ChangeToBlack(2));
                }
                /*
                else if (yellowCat.activeSelf)
                {
                    // Trigger Death Animation
                    animatorY.SetBool("isDying", true);
                }
                */
               
            }
            /*
            // Switch to Character 3
            else if (pressedThree && !yellowCat.activeSelf)
            {
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

                // Trigger Switch
                StartCoroutine(ChangeToYellow(2)); 
            }
            */

        }
    }

    IEnumerator ChangeToWhite(float time1)
    {
        yield return new WaitForSeconds(time1);

        Debug.Log("changedToWhite");

        // Reset Death Status
        /*
        if (animatorB.GetBool("isDying"))
        {
            animatorB.SetBool("isDying", false);
        }
        /*
        else if (animatorY.GetBool("isDying"))
        {
            animatorY.SetBool("isDying", false);
        }
        */

        // Change Character
        blackCat.SetActive(false);
        whiteCat.SetActive(true);
        //yellowCat.SetActive(false);

        // Update Character Status
        firstSkin = true;
        secondSkin = false;
        thirdSkin = false;
    }
    IEnumerator ChangeToBlack(float time2)
    {
        yield return new WaitForSeconds(time2);

        Debug.Log("changedToBlack");
        // Reset Death Status
        if (animatorW.GetBool("isDying"))
        {
            animatorW.SetBool("isDying", false);
        }
        /*
        else if (animatorY.GetBool("isDying"))
        {
            animatorY.SetBool("isDying", false);
        }
        */

        // Change Character
        blackCat.SetActive(true);
        whiteCat.SetActive(false);
        //yellowCat.SetActive(false);

        // Update Character Status
        firstSkin = false;
        secondSkin = true;
        thirdSkin = false;

    }
    IEnumerator ChangeToYellow(float time3)
    {
        yield return new WaitForSeconds(time3);

        // Reset Death Status
        if (animatorB.GetBool("isDying"))
        {
            animatorB.SetBool("isDying", false);
        }
        else if (animatorW.GetBool("isDying"))
        {
            animatorW.SetBool("isDying", false);
        }

        // Change Character
        blackCat.SetActive(false);
        whiteCat.SetActive(false);
        //yellowCat.SetActive(true);

        // Update Character Status
        firstSkin = false;
        secondSkin = false;
        thirdSkin = true;

    }

    // Update is called once per frame
    void Update()
    {
        // Handle Keyboard Input
        handleSwitch();
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
