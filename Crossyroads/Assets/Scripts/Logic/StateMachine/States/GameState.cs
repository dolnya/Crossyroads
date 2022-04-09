using UnityEngine;
using CrossyInputNS;
using UnityEngine.Events;
using UI;
using Camera;
using Generator;
namespace Logic
{
    public class GameState : BaseState
    {

        private CrossyInput crossyInput;
        private UnityAction transitionToMenuState;
        private UnityAction transitionToLoseState;
        private GameView gameView;
        private PlayerMovement playerMovement;
        private CameraMovement cameraMovement;
        private LaneGenerator laneGenerator;



        public GameState(CrossyInput crossyInput,UnityAction transitionToMenuState, 
            UnityAction transitionToLoseState, GameView gameView, CameraMovement cameraMovement,
            LaneGenerator laneGenerator, PlayerMovement playerMovement
            )
        {
            this.crossyInput = crossyInput;
            this.transitionToMenuState = transitionToMenuState;
            this.transitionToLoseState = transitionToLoseState;
            this.gameView = gameView;
            this.cameraMovement = cameraMovement;
            this.laneGenerator = laneGenerator;
            this.playerMovement = playerMovement;
            
        }


        public override void InitState()
        {
            Debug.Log("INIT GAME");
            if (gameView != null)
            {
                gameView.ShowView();
            }
            
            playerMovement.OnDieAddListener(transitionToLoseState);
            crossyInput.Addlistener(InputType.Esc, ToMenuState);
            
            crossyInput.Addlistener(InputType.Forward, playerMovement.MoveForward);
            crossyInput.Addlistener(InputType.Back, playerMovement.MoveBackward);
            crossyInput.Addlistener(InputType.Left, playerMovement.MoveLeft);
            crossyInput.Addlistener(InputType.Right, playerMovement.MoveRight);
        
            playerMovement.InitPlayer();
           


        }
        public override void UpdateState()
        {
            Debug.Log("UPDATE GAME");
            cameraMovement.UpdateMovement();
        }
        public override void DisposeState()
        {
            
            //playerMovement.ResterPlayer();
            Debug.Log("DISPOSE GAME");
            crossyInput.ClearInputs();
            if (gameView != null)
            {
                gameView.HideView();
               
            }
        }

        public void ToMenuState()
        {
            transitionToMenuState.Invoke();
            Debug.Log("To Menu");
        }
        
        
    }
}

