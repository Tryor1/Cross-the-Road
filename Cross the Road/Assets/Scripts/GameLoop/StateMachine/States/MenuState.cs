using InputControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLoop
{
    public class MenuState : BaseState
    {
        private GameInput gameInput;
        public MenuState(GameInput gameInput)
        {
            this.gameInput = gameInput;
        }

        public override void InitState()
        {
            Debug.Log("It works!");
        }

        public override void UpdateState()
        {
            Debug.Log("Update");
        }
        public override void DisposeState()
        {
            gameInput.ClearInputs();
        }
    }
}
