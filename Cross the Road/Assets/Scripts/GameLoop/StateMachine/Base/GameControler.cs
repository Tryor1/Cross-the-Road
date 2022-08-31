using InputControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLoop
{
    public class GameControler : MonoBehaviour
    {
        #region States
        private MenuState menuState; 
        #endregion

        private BaseState activeState;

        [SerializeField]
        private GameInput gameInput;

        private void Start()
        {
            menuState = new MenuState(gameInput);

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