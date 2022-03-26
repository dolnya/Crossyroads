using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Logic;
using UnityEngine.Events;
using System;

namespace CrossyInputNS
{
    public enum InputType
    {
        Forward,
        Back,
        Left,
        Right,
        Any,
        Esc
    }
    
    public class CrossyInput : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput playerInput;

        private UnityAction onForward;
        private UnityAction onBack;
        private UnityAction onLeft;
        private UnityAction onRight;
        private UnityAction onAny;
        private UnityAction onEsc;

        //public void OnKeyDownAddListener(UnityAction callback)
        //{
        //    onKeyDown = callback;
        //}
        public void Addlistener(InputType inputType, UnityAction callback)
        {
            switch (inputType)
            {
                case InputType.Forward:
                    onForward += callback;
                    break;
                case InputType.Back:
                    onBack += callback;
                    break;
                case InputType.Left:
                    onLeft += callback;
                    break;

                case InputType.Right:
                    onRight += callback;
                    break;
                case InputType.Any:
                    onAny += callback;
                    break;
                case InputType.Esc:
                    onEsc += callback;
                    break;

            }
        }
        public void ClearInputs()
        {
            onBack = null;
            onLeft = null;
            onForward = null;
            onRight = null;
            onAny = null;
            onEsc = null;
        }
        

        public void OnMoveForward(InputAction.CallbackContext ctx)
        {
            if( ctx.action.WasPerformedThisFrame())
            {
                Debug.Log("Forward");

                onForward?.Invoke();
            }
        }

        public void OnMoveBack(InputAction.CallbackContext ctx)
        {
            if (ctx.action.WasPerformedThisFrame())
            {
                Debug.Log("Back");
                onBack?.Invoke();
                
            }
        }
        public void OnMoveLeft(InputAction.CallbackContext ctx)
        {
            if (ctx.action.WasPerformedThisFrame())
            {
                Debug.Log("Left");
                onLeft?.Invoke();
            }
        }
        public void OnMoveRight(InputAction.CallbackContext ctx)
        {
            if (ctx.action.WasPerformedThisFrame())
            {
                Debug.Log("Right");
                onRight?.Invoke();
            }
        }
        public void OnAnyKeyPresses(InputAction.CallbackContext ctx)
        {
            if (ctx.action.WasPerformedThisFrame())
            {
                Debug.Log("Any is Pressed");
                onAny?.Invoke();
            }
        }
        public void OnAnyEscPresses(InputAction.CallbackContext ctx)
        {
            if (ctx.action.WasPerformedThisFrame())
            {
                Debug.Log("Any is Pressed");
                onEsc?.Invoke();
            }
        }



    }

}