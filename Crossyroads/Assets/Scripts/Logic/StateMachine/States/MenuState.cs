using UnityEngine;
using CrossyInputNS;
using UI;
using UnityEngine.Events;

namespace Logic
{
    public class MenuState : BaseState
    {

        private CrossyInput crossyInput;
        private UnityAction transitionToGameState;
        private MenuView menuView;
        public MenuState(CrossyInput crossyInput, UnityAction transitionToGameState, MenuView menuView)
        {
            this.crossyInput = crossyInput;
            this.transitionToGameState = transitionToGameState;
            this.menuView = menuView;
        }

        public override void InitState()
        {
                menuView.ShowView();
            
                Debug.Log("INIT MENU");
            //crossyInput.OnKeyDownAddListener(Test);
            crossyInput.Addlistener(InputType.Any, Test);
            crossyInput.Addlistener(InputType.Any, ToGameState);
            
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
              
        public void Test()
        {
            Debug.Log("Test Menu");
        }
        public void ToGameState()
        {
            transitionToGameState.Invoke();
            
            Debug.Log("To Game State invoke called");
        }
    }
}

