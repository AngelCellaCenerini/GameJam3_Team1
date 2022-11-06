using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterSwitcher : MonoBehaviour
{
    CharacterSwitch characterSwitch;
    bool pressedRight;
    bool pressedLeft;

    [SerializeField] private MeshFilter currentCharacter;
    [SerializeField] private Mesh[] chosenCharacter;
    private int currentModel = 0;

    // Menu UI
    [SerializeField] public RawImage currentCatIcon;
    [SerializeField] public Texture[] chosenCatIcon;
    private int currentCharacterIcon = 0;
    public Sprite arrowIcon;

    // Skin Menu & Skins
    public GameObject skinMenu;
    public bool firstSkin = true;
    public bool secondSkin = false;
    public bool thirdSkin = false;

    void Awake()
    {
        // Handle Input Action
        characterSwitch = new CharacterSwitch();
        characterSwitch.SwitchMesh.SwitchRight.performed += switchRight;
    }

    public void switchRight(InputAction.CallbackContext context)
    {
        pressedRight = context.ReadValueAsButton();
    }

    public void handleSwitch()
    {
        // Check if Skin Menu is active
        if (skinMenu.activeSelf)
        {
            // Check for Input
            if (pressedRight)
            {
                // Go to next Mesh
                currentModel++;
                // Go to next Icon
                currentCharacterIcon++;

                // Reset Mesh Array
                if (currentModel >= chosenCharacter.Length)
                {
                    currentModel = 0;
                }
                // Reset Icon Array
                if (currentCharacterIcon >= chosenCatIcon.Length)
                {
                    currentCharacterIcon = 0;
                }

                // Reset State
                pressedRight = false;

                // Update Abilities
                checkCurrentMesh();
            }

            // Update Meshes and Icons
            currentCharacter.mesh = chosenCharacter[currentModel];
            currentCatIcon.texture = chosenCatIcon[currentCharacterIcon];
        }
    }

    void checkCurrentMesh()
    {
        if (currentModel == 0)
        {
            firstSkin = true;
            secondSkin = false;
            thirdSkin = false;
        }
        else if (currentModel == 1)
        {
            firstSkin = false;
            secondSkin = true;
            thirdSkin = false;
        }
        else if (currentModel == 2)
        {
            firstSkin = false;
            secondSkin = false;
            thirdSkin = true;
        }
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
