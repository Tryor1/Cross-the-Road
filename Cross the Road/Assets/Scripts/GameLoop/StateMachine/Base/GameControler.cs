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
    public class GameControler : MonoBehaviour
    {
        #region States
        private MenuState menuState;
        private GameState gameState;
        #endregion

        private BaseState activeState;

        private UnityAction changeToGameState;

        [SerializeField]
        private GameInput gameInput;

        #region Views
        [SerializeField]
        private MenuView menuView;
        [SerializeField]
        private GameView gameView;
        #endregion

        [SerializeField]
        private LaneGenerator laneGenerator;

        [SerializeField]
        private CarStorage carStorage;

        [SerializeField]
        private PlayerMovement playerMovement;

        private void Start()
        {
            changeToGameState += () => ChangeState(gameState);

            menuState = new MenuState(gameInput, changeToGameState, menuView, laneGenerator, carStorage);
            gameState = new GameState(gameInput, gameView, playerMovement, laneGenerator, carStorage);

            ChangeState(menuState);
        }
        private void Update()
        {
            activeState?.UpdateState();
        }
        private void OnDestroy()
        {

        }
        private void ChangeState(BaseState newState)
        {
            activeState?.DisposeState();
            activeState = newState;
            newState.InitState();
        }
    }
}