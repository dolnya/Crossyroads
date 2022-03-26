using UnityEngine;
using CrossyInputNS;
namespace Logic
{
    public class MenuState : BaseState
    {

        private CrossyInput crossyInput;
        public override void InitState()
        {
            Debug.Log("INIT MENU");
            //crossyInput.OnKeyDownAddListener(Test);
            crossyInput.Addlistener(InputType.Back, Test);
        }
        public override void UpdateState()
        {
            Debug.Log("UPDATE MENU");
        }
        public override void DisposeState()
        {
            Debug.Log("DISPOSE MENU");
        }
              
        public void Test()
        {
            Debug.Log("Test Menu");
        }
    }
}

