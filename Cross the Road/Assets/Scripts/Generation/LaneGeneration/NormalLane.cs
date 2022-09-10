using Core;
using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace Generation
{
    public class NormalLane : Lane
    {
        [SerializeField]
        private CarGenerator carGenerator;
        [SerializeField]
        private MeshRenderer meshRenderer;

        [SerializeField] private Color color1;
        [SerializeField] private Color color2;

        private UnityAction onDespawn;

        public override void InitializeLane(CarType type, CarPool<Car> pool, int spawnPointIndex)
        {
            carGenerator.InitializeGenerator(type, pool, spawnPointIndex);
            StartCoroutine(GenerateCar(3f));
        }

        private IEnumerator GenerateCar(float timeBetweenSpawns)
        {
            while (true)
            {
                carGenerator.SpawnCar(transform.parent);
                yield return new WaitForSeconds(timeBetweenSpawns);
            }
        }

        public void SetColor(int count)
        {
            if (count % 2 == 0)
            {
                meshRenderer.material.color = color1;
            }
            else
            {
                meshRenderer.material.color = color2;
            }
        }

        public void OnDespawnAddListener(UnityAction callback)
        {
            onDespawn = callback;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Border"))
            {
                StopAllCoroutines();
                carGenerator.DespawnAllCars();
                onDespawn.Invoke();
                Destroy(this.gameObject);
            }
        }
    } 
}
