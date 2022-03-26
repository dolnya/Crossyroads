using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

namespace Logic
{
    public class GameController : MonoBehaviour
    {
        #region STATES
        private MenuState menuState;
        private BaseState currentlyActiveState;

        #endregion


        private void Start()
        {
            menuState = new MenuState();
            ChangeState(menuState);
        }
        private void Update()
        {
            currentlyActiveState?.UpdateState();
        }
        private void OnDestroy()
        {

        }
        private void ChangeState(BaseState newState)
        {
            currentlyActiveState?.DisposeState();
            currentlyActiveState = newState;
            newState.InitState();
        }


    }
}