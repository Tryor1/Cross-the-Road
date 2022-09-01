using InputControl;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace GameLoop
{
    public class MenuState : BaseState
    {
        private GameInput gameInput;
        private UnityAction changeToGameState;
        private MenuView menuView;
        public MenuState(GameInput gameInput, UnityAction changeToGameState, MenuView menuView)
        {
            this.gameInput = gameInput;
            this.changeToGameState = changeToGameState;
            this.menuView = menuView;
        }

        public override void InitState()
        {
            menuView.ShowView();
            gameInput.AddListener(InputType.Any, changeToGameState.Invoke);
        }

        public override void UpdateState()
        {
            
        }
        public override void DisposeState()
        {
            gameInput.ClearInputs();
            menuView.HideView();
        }
    }
}
