using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLoop
{
    public class GameControler : MonoBehaviour
    {
        private BaseState activeState;

        private void Start()
        {

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