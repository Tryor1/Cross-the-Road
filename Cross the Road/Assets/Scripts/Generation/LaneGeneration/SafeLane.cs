using Core;
using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace Generation
{
    public class SafeLane : Lane
    {
        private UnityAction onDespawn;

        public override void InitializeLane(CarType type, CarPool<Car> pool, int spawnPointIndex, int difficulty)
        {

        }

        public void OnDespawnAddListener(UnityAction callback)
        {
            onDespawn = callback;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Border"))
            {
                onDespawn.Invoke();
                Destroy(this.gameObject);
            }
        }
    } 
}
