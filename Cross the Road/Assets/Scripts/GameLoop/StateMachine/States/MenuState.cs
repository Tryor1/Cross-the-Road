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
        private CarStorage carStorage;
        public MenuState(GameInput gameInput, UnityAction changeToGameState, MenuView menuView, LaneGenerator laneGenerator, CarStorage carStorage)
        {
            this.gameInput = gameInput;
            this.changeToGameState = changeToGameState;
            this.menuView = menuView;
            this.laneGenerator = laneGenerator;
            this.carStorage = carStorage;
        }

        public override void InitState()
        {
            menuView.ShowView();
            carStorage.InitializeStorage();
            gameInput.AddListener(InputType.Any, changeToGameState.Invoke);
            laneGenerator.GenerateLevel(20, carStorage.CarsPool);
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
