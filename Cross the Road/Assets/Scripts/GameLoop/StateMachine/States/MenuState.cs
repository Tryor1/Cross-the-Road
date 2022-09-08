using Generation;
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
        private LaneGenerator laneGenerator;
        public MenuState(GameInput gameInput, UnityAction changeToGameState, MenuView menuView, LaneGenerator laneGenerator)
        {
            this.gameInput = gameInput;
            this.changeToGameState = changeToGameState;
            this.menuView = menuView;
            this.laneGenerator = laneGenerator;
        }

        public override void InitState()
        {
            menuView.ShowView();
            gameInput.AddListener(InputType.Any, changeToGameState.Invoke);
            laneGenerator.GenerateLevel(20);
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
