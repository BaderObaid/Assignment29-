using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    private PlayerInputActions playerInputAction;

    private void Awake()
    {

        playerInputAction = new PlayerInputActions();
        playerInputAction.Player.Enable();

        playerInputAction.Player.Interact.performed += Interact_performed;

    }

    private void Interact_performed (UnityEngine.InputSystem.InputAction.CallbackContext obj) // this line is written from Unity system and is required to do the perform function 
    {

    OnInteractAction?.Invoke(this, EventArgs.Empty);

    // or we can do it like this:-

    //    if (OnInteractAction != null)
    //    {

    //    OnInteractAction ( this, EventArgs.Empty);
    //    //Debug.Log(obj);

    //    }

    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputAction.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;

       // Debug.Log(inputVector);

        inputVector = inputVector.normalized;

        return inputVector;


    }



}
