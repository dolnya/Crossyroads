using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using CrossyInputNS;
using UI;
using Generator;
using Camera;
using Core;
       

namespace Logic
{
    public class GameController : MonoBehaviour
    {
        #region States
        private MenuState menuState;
        private GameState gameState;
        private LoseState loseState;
        private BaseState currentlyActiveState;
        #endregion

        #region Views
        [SerializeField]
        MenuView menuView;
        [SerializeField]
        GameView gameView;
        [SerializeField]
        LoseView loseView;
        #endregion

        #region Transitions
        private UnityAction transitionToGameState;
        private UnityAction transitionToMenuState;
        private UnityAction transitionToLoseState;
        #endregion

        [SerializeField]
        private LaneGenerator laneGenerator;
        [SerializeField]
        private CrossyInput crossyInput;
        [SerializeField]
        private PlayerMovement playerMovement;
        [SerializeField]
        private CameraMovement cameraMovement;
        [SerializeField]
        private CarStorage carStorage;

        private PointsSystem pointsSystem;
        private void Start()
        {
            
            transitionToGameState = () => ChangeState(gameState);
            transitionToMenuState = () => ChangeState(menuState);
            transitionToLoseState = () => ChangeState(loseState);
            menuState = new MenuState(crossyInput, transitionToGameState, menuView, gameView, loseView, cameraMovement, laneGenerator, carStorage);
            gameState = new GameState(crossyInput, transitionToMenuState, transitionToLoseState, gameView, cameraMovement, laneGenerator, playerMovement, pointsSystem);
            loseState = new LoseState(crossyInput, transitionToMenuState, transitionToGameState, loseView);
            
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
