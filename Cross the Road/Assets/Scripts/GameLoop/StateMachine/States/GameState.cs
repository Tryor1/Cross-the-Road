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
        private PlayerControler playerMovement;
        private LaneGenerator laneGenerator;
        private CarStorage carStorage;
        private CameraMovement cameraMovement;
        public GameState(GameInput gameInput, GameView gameView, PlayerControler playerMovement, LaneGenerator laneGenerator, CarStorage carStorage, CameraMovement cameraMovement)
        {
            this.gameInput = gameInput;
            this.gameView = gameView;
            this.playerMovement = playerMovement;
            this.laneGenerator = laneGenerator;
            this.carStorage = carStorage;
            this.cameraMovement = cameraMovement;
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
            cameraMovement.MoveCamera();
        }
        public override void DisposeState()
        {
            gameInput.ClearInputs();
            gameView.HideView();
        }
    }
}
