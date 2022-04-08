using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossyInputNS;
using UI;
using UnityEngine.Events;

namespace Logic
{
    public class LoseState : BaseState
    {
        private CrossyInput crossyInput;
        private UnityAction transitionToGameState;
        private UnityAction transitionToMenuState;

        private LoseView loseView;


        public LoseState(CrossyInput crossyInput, UnityAction transitionToMenuState , UnityAction transitionToGameState, LoseView loseView
            )
        {
            this.crossyInput = crossyInput;
            this.transitionToMenuState = transitionToMenuState;
            this.transitionToGameState = transitionToGameState;
            this.loseView = loseView;

        }

        public override void InitState()
        {
            loseView.ShowView();

            Debug.Log("INIT LOSE");
            crossyInput.Addlistener(InputType.Enter, ToMenuState);

        }
        public override void UpdateState()
        {
            Debug.Log("UPDATE LOSE");

        }
        private void ToMenuState()
        {
            transitionToMenuState.Invoke();
        }

        public override void DisposeState()
        {
            Debug.Log("DISPOSE LOSE");
            crossyInput.ClearInputs();
            if (loseView != null)
            {
                loseView.HideView();
            }
        }
    }
}
