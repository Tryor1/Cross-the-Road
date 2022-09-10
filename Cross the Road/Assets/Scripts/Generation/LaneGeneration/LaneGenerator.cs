using Core;
using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Generation
{
    public class LaneGenerator : MonoBehaviour
    {
        [SerializeField]
        private NormalLane lanePrefab;
        [SerializeField]
        private SafeLane safeLanePrefab;

        [SerializeField]
        private Transform lanesParent;
        [SerializeField]
        private Transform startPosition;
        [SerializeField]
        private float distance = 1.8f;

        private int counter;
        private CarPool<Car> pool;
        
        public void GenerateLevel(int lanesCount, CarPool<Car> pool)
        {
            this.pool = pool;

            for (int i = 1; i < 12; i++)
            {
                var safeLane = Instantiate(safeLanePrefab, lanesParent);
                safeLane.transform.localPosition = startPosition.localPosition + Vector3.right * distance * -i;
                safeLane.OnDespawnAddListener(OnLaneDespawn); 
            }

            for (int i=0; i<lanesCount; i++)
            {
                GenerateLane(pool);
            }
        }

        public void GenerateLane(CarPool<Car> pool)
        {
            if (counter % 5 == 4)
            {
                var safeLane = Instantiate(safeLanePrefab, lanesParent);
                safeLane.transform.localPosition = startPosition.localPosition + Vector3.right * distance * counter;
                counter++;
                safeLane.OnDespawnAddListener(OnLaneDespawn);
            }
            else
            {
                var lane = Instantiate(lanePrefab, lanesParent);
                lane.transform.localPosition = startPosition.localPosition + Vector3.right * distance * counter;
                lane.SetColor(counter);
                var randomCar = Random.Range(0, 9);
                var randomIndex = Random.Range(0, 2);
                lane.InitializeLane((CarType)randomCar, pool, randomIndex, counter);
                lane.OnDespawnAddListener(OnLaneDespawn);
                counter++;
            }
        }

        public void OnLaneDespawn()
        {
            GenerateLane(pool);
        }
    } 
}
