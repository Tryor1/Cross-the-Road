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

        [SerializeField]
        private LaneGenerator laneGenerator;
        #endregion

        private void Start()
        {
            changeToGameState += () => ChangeState(gameState);

            menuState = new MenuState(gameInput, changeToGameState, menuView, laneGenerator);
            gameState = new GameState(gameInput, gameView);

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