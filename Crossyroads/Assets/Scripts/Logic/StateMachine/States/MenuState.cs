using UnityEngine;
using CrossyInputNS;
using UI;
using UnityEngine.Events;
using System;
using Camera;
using Generator;

namespace Logic
{
    public class MenuState : BaseState
    {

        private CrossyInput crossyInput;
        private UnityAction transitionToGameState;
        private MenuView menuView;
        private GameView gameView;
        private LoseView loseView;
        private CameraMovement cameraMovement;



        public MenuState(CrossyInput crossyInput, UnityAction transitionToGameState, MenuView menuView,
            GameView gameView, LoseView loseView, CameraMovement cameraMovement)
        {
            this.crossyInput = crossyInput;
            this.transitionToGameState = transitionToGameState;
            this.menuView = menuView;
            this.gameView = gameView;
            this.loseView = loseView;
            this.cameraMovement = cameraMovement;

        }

        public override void InitState()
        {
            gameView.HideView();
            loseView.HideView();
            menuView.ShowView();
            cameraMovement.RestetPosition();
            Debug.Log("INIT MENU");
            crossyInput.Addlistener(InputType.Any, transitionToGameState);
            

        }
        public override void UpdateState()
        {
            Debug.Log("UPDATE MENU");

        }
        
        public override void DisposeState()
        {
            Debug.Log("DISPOSE MENU");
            crossyInput.ClearInputs();
            if (menuView != null)
            {
                menuView.HideView();
            }
        }
              


    }
}

