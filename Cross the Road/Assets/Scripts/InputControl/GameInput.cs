using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace InputControl
{
    public enum InputType
    {
        Forward,
        Backward,
        Right,
        Left,
    }

    public class GameInput : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput playerInput;

        private UnityAction onForward;
        private UnityAction onBackward;
        private UnityAction onRight;
        private UnityAction onLeft;

        public void AddListener(InputType inputType, UnityAction callback)
        {
            switch (inputType)
            {
                case InputType.Forward:
                    onForward += callback;
                    break;
                case InputType.Backward:
                    onBackward += callback;
                    break;
                case InputType.Right:
                    onRight += callback;
                    break;
                case InputType.Left:
                    onLeft += callback;
                    break;
            }
        }

        public void ClearInputs()
        {
            onBackward = null;
            onForward = null;
            onRight = null;
            onLeft = null;
        }

        public void OnMoveForward(InputAction.CallbackContext ctx)
        {
            if (ctx.action.WasPerformedThisFrame())
            {
                onForward?.Invoke();
            }
        }
        public void OnMoveBackward(InputAction.CallbackContext ctx)
        {

            if (ctx.action.WasPerformedThisFrame())
            {
                onBackward?.Invoke();
            }
        }
        public void OnMoveRight(InputAction.CallbackContext ctx)
        {

            if (ctx.action.WasPerformedThisFrame())
            {
                onRight?.Invoke();
            }
        }
        public void OnMoveLeft(InputAction.CallbackContext ctx)
        {

            if (ctx.action.WasPerformedThisFrame())
            {
                onLeft?.Invoke();
            }
        }
    } 
}
