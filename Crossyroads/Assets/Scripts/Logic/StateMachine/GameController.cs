using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using CrossyInputNS;

namespace Logic
{
    public class GameController : MonoBehaviour
    {
        #region STATES
        private MenuState menuState;
        private BaseState currentlyActiveState;

        #endregion
        [SerializeField]
        private CrossyInput crossyInput;




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

        private void Print1()
        {
            Debug.Log("1");
        }
        public void Print2()
        {
            Debug.Log("2");
        }

       

    }
}
