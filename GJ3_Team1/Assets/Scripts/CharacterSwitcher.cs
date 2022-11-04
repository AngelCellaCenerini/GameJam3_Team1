using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwitcher : MonoBehaviour
{
    CharacterSwitch characterSwitch;
    bool pressedRight;
    bool pressedLeft;

   [SerializeField] private MeshFilter currentCharacter;
   [SerializeField] private Mesh[] chosenCharacter;

    private int currentModel = 0;

    void Awake()
    {
        // Handle Input Action
        characterSwitch = new CharacterSwitch();
        characterSwitch.SwitchMesh.SwitchRight.performed += switchRight;
        characterSwitch.SwitchMesh.SwitchLeft.performed += switchLeft; 
    }

    public void switchRight(InputAction.CallbackContext context)
    {
        pressedRight = context.ReadValueAsButton();
    }

    public void switchLeft(InputAction.CallbackContext context)
    {
            pressedLeft = context.ReadValueAsButton();
    }

    public void handleSwitch()
    {
        // Check for Input
        if (pressedRight)
        {
            // Go to next Mesh
            currentModel++;
            // onSwitch();
            // Debug.Log(currentModel);

            // Reset Array
            if (currentModel >= chosenCharacter.Length)
            {
                currentModel = 0;
            }

            // Reset State
            pressedRight = false;
        }
        else if (pressedLeft)
        {
            // Switch to previous character
            // Go to next Mesh
            //Debug.Log(currentModel);
            //currentModel--;
            //onSwitch();
            //pressedLeft = false;

            /*
            // Reset Array
            if (currentModel <= 1)
            {
                //currentModel = 3;
            }
            // Reset State
            pressedLeft = false;
            */
        }

        currentCharacter.mesh = chosenCharacter[currentModel];
    }

    void onSwitch()
    {
        if (currentModel <= 1) {
            // currentModel = 3;
        }
        if (currentModel >= chosenCharacter.Length)
        {
            currentModel = 0;
        }

        currentCharacter.mesh = chosenCharacter[currentModel];
    }

    // Update is called once per frame
    void Update()
    {
        // Handle Keyboard Input
        handleSwitch();

       /* characterSwitch.SwitchMesh.Switch.ReadValueAsButton();
        if (isSpaceKeyHeld)
        {
            Debug.Log("SPACEBAR");
            currentCharacter.mesh = chosenCharacter[currentModel];
            // Go to next Mesh
            currentModel++;
            // Reset Array
            if (currentModel >= chosenCharacter.Length)
            {
                currentModel = 0;
            }
         
        }
       */   
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
