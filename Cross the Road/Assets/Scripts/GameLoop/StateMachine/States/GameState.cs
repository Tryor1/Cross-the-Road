using InputControl;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace GameLoop
{
    public class GameState : BaseState
    {
        private GameInput gameInput;
        private GameView gameView;
        public GameState(GameInput gameInput, GameView gameView)
        {
            this.gameInput = gameInput;
            this.gameView = gameView;
        }

        public override void InitState()
        {
            gameView.ShowView();
            Debug.Log("It works!");
        }

        public override void UpdateState()
        {
            Debug.Log("Game");
        }
        public override void DisposeState()
        {
            gameInput.ClearInputs();
            gameView.HideView();
        }
    }
}
