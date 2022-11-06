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
        if (isPressed)
        {
            Debug.Log(isPressed);
            if (!skinMenu.activeSelf)
            {
                skinMenu.SetActive(true);
                isPressed = false;
                Debug.Log(isPressed);
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
