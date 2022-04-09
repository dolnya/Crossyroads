using UnityEngine;
using CrossyInputNS;
using UI;
using UnityEngine.Events;
using System;
using Camera;
using Generator;
using CarPools;
using LaneGen;
using System.Collections;
using System.Collections.Generic;



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
        private LaneGenerator laneGenerator;
        private CarStorage carStorage;


        public MenuState(CrossyInput crossyInput, UnityAction transitionToGameState, MenuView menuView,
            GameView gameView, LoseView loseView, CameraMovement cameraMovement, LaneGenerator laneGenerator, CarStorage carStorage)
        {
            this.crossyInput = crossyInput;
            this.transitionToGameState = transitionToGameState;
            this.menuView = menuView;
            this.gameView = gameView;
            this.loseView = loseView;
            this.cameraMovement = cameraMovement;
            this.carStorage = carStorage;
            this.laneGenerator = laneGenerator;

        }

        public override void InitState()
        {
            gameView.HideView();
            loseView.HideView();
            menuView.ShowView();
            Debug.Log("INIT MENU");
            carStorage.InitializeStorage();
            crossyInput.Addlistener(InputType.Any, transitionToGameState);
            laneGenerator.GenerateLevel(carStorage.CarsPool, 20);


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

