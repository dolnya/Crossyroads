using UnityEngine;
using CrossyInputNS;
using UI;
using UnityEngine.Events;

using Generator;

namespace Logic
{
    public class MenuState : BaseState
    {

        private CrossyInput crossyInput;
        private UnityAction transitionToGameState;
        private MenuView menuView;
        private LaneGenerator laneGenerator;
        

        public MenuState(CrossyInput crossyInput, UnityAction transitionToGameState, MenuView menuView, LaneGenerator laneGenerator)
        {
            this.crossyInput = crossyInput;
            this.transitionToGameState = transitionToGameState;
            this.menuView = menuView;
            this.laneGenerator = laneGenerator;
        }

        public override void InitState()
        {
            menuView.ShowView();
            
            Debug.Log("INIT MENU");
            crossyInput.Addlistener(InputType.Any, Test);
            crossyInput.Addlistener(InputType.Any, ToGameState);
         
            //laneGenerator.GenerateLevel(15);
            laneGenerator.GenerateLevelList(15);
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

