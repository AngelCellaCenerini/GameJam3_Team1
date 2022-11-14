using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeCharacterUI : MonoBehaviour
{
    public GameObject skinMenu;
    OpenSkinMenu characterSwitch;
    public bool isPressed;

    void Awake()
    {
        // Handle Input Action
        characterSwitch = new OpenSkinMenu();
        characterSwitch.SkinMenu.OpenSkinMenu.performed += triggerMenu;
    }

    public void triggerMenu(InputAction.CallbackContext context)
    {
        isPressed = context.ReadValueAsButton();
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
            else
            {
                skinMenu.SetActive(false);
                isPressed = false;
            }
        }
        
    }

    void Update()
    {
        handleMenu();
    }
}
