using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using CrossyInputNS;
using UI;
using Generator;

namespace Logic
{
    public class GameController : MonoBehaviour
    {
        #region States
        private MenuState menuState;
        private GameState gameState;
        private BaseState currentlyActiveState;
        #endregion

        #region Views
        [SerializeField]
        MenuView menuView;
        [SerializeField]
        GameView gameView;
        #endregion

        #region Transitions
        private UnityAction transitionToGameState;
        private UnityAction transitionToMenuState;
        #endregion

        [SerializeField]
        private LaneGenerator laneGenerator;
        [SerializeField]
        private CrossyInput crossyInput;
        private void Start()
        {
            
            transitionToGameState = () => ChangeState(gameState);
            transitionToMenuState = () => ChangeState(menuState);
            menuState = new MenuState(crossyInput, transitionToGameState, menuView, laneGenerator);
            gameState = new GameState(crossyInput, transitionToMenuState, gameView);  
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
