using UnityEngine;
using CrossyInputNS;
using UnityEngine.Events;
using UI;
using Generator;
namespace Logic
{
    public class GameState : BaseState
    {

        private CrossyInput crossyInput;
        private UnityAction transitionToMenuState;
        private GameView gameView;

        public GameState(CrossyInput crossyInput,UnityAction transitionToMenuState, GameView gameView)
        {
            this.crossyInput = crossyInput;
            this.transitionToMenuState = transitionToMenuState;
            this.gameView = gameView;
        }


        public override void InitState()
        {
            Debug.Log("INIT GAME");
            if (gameView != null)
            {
                gameView.ShowView();
            }
            crossyInput.Addlistener(InputType.Esc, ToMenuState);


        }
        public override void UpdateState()
        {
            Debug.Log("UPDATE GAME");
        }
        public override void DisposeState()
        {
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

