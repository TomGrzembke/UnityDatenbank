using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputExample : MonoBehaviour
{
    /// <summary>
    /// The input actions for the playerInput
    /// </summary>
    InputControls inputActions;

    private void Awake()
    {
        inputActions = new InputControls();
        inputActions.InputActionMap.WASD.performed += ctx => Movement(ctx.ReadValue<Vector2>());
        inputActions.InputActionMap.WASD.canceled += ctx => Movement(ctx.ReadValue<Vector2>());

    }

    void Movement(Vector2 direction)
    {

        //Add movement logic here
    }
}
