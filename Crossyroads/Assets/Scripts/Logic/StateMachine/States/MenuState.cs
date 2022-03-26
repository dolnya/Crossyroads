using UnityEngine;
namespace Logic
{
    public class MenuState : BaseState
    {
        public override void InitState()
        {
            Debug.Log("INIT MENU");
        }
        public override void UpdateState()
        {
            Debug.Log("UPDATE MENU");
        }
        public override void DisposeState()
        {
            Debug.Log("DISPOSE MENU");
        }
    }
}

