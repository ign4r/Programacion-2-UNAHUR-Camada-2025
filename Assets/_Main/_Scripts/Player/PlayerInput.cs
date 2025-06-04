using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    private Vector3 inputDirection;
    private bool wasInputActive;

    public Vector3 Axis => inputDirection;

    public event Action OnInputStarted;
    public event Action OnInputStopped;

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        inputDirection = new Vector3(inputX, inputY, 0f);

        bool isInputActive = (inputX != 0f || inputY != 0f);

        if (isInputActive && !wasInputActive)
        {
            OnInputStarted?.Invoke();
        }
        else if (!isInputActive && wasInputActive)
        {
            OnInputStopped?.Invoke();
        }

        wasInputActive = isInputActive;
    }

}

