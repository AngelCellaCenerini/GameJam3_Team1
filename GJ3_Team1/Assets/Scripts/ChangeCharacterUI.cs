using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeCharacterUI : MonoBehaviour
{
    public GameObject skinMenu;
    OpenSkinMenu characterSwitch;
    public bool isPressed;
    public bool isClosed;
    public bool choiceIsConfirmed = false;

    void Awake()
    {
        // Handle Input Action
        characterSwitch = new OpenSkinMenu();
        characterSwitch.SkinMenu.OpenSkinMenu.performed += triggerMenu;
        characterSwitch.SkinMenu.CloseSkinMenu.performed += untriggerMenu;
    }

    public void triggerMenu(InputAction.CallbackContext context)
    {
        isPressed = context.ReadValueAsButton();
    }

    public void untriggerMenu(InputAction.CallbackContext context)
    {
        isClosed = context.ReadValueAsButton();
    }

    public void handleMenu()
    {
        // Open Menu
        if (isPressed)
        {
            if (!skinMenu.activeSelf)
            {
                skinMenu.SetActive(true);
                isPressed = false;
            }
        }

        // Close menu
        if (isClosed)
        {
            choiceIsConfirmed = true; 

            if (skinMenu.activeSelf)
            {
                skinMenu.SetActive(false);
                isClosed = false;
            }
        }
    }

    public void openMenu()
    {
        if (!skinMenu.activeSelf)
        {
            skinMenu.SetActive(true);
        }      
    }

    public void closeMenu()
    {
        if (skinMenu.activeSelf)
        {
            skinMenu.SetActive(false);
        }
    }

    void Update()
    {
        handleMenu();
    }
}
