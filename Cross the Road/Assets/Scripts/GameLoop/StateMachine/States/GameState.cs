using Core;
using Generation;
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
        private PlayerMovement playerMovement;
        private LaneGenerator laneGenerator;
        private CarStorage carStorage;
        public GameState(GameInput gameInput, GameView gameView, PlayerMovement playerMovement, LaneGenerator laneGenerator, CarStorage carStorage)
        {
            this.gameInput = gameInput;
            this.gameView = gameView;
            this.playerMovement = playerMovement;
            this.laneGenerator = laneGenerator;
            this.carStorage = carStorage;
        }

        public override void InitState()
        {
            gameView.ShowView();
            gameInput.AddListener(InputType.Backward, playerMovement.MoveBack);
            gameInput.AddListener(InputType.Forward, playerMovement.MoveForward);
            gameInput.AddListener(InputType.Right, playerMovement.MoveRight);
            gameInput.AddListener(InputType.Left, playerMovement.MoveLeft);
        }

        public override void UpdateState()
        {

        }
        public override void DisposeState()
        {
            gameInput.ClearInputs();
            gameView.HideView();
        }
    }
}
