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
        /*
        var startLane = Instantiate(safeLanePrefab, lanesParent);
        startLane.transform.localPosition = startPosition.localPosition + Vector3.right* distance * -1;
        */
        public void GenerateLevel(int lanesCount, CarPool<Car> pool)
        {
            for(int i=0; i<lanesCount; i++)
            {
                GenerateLane(pool);
            }
        }

        public void GenerateLane(CarPool<Car> pool)
        {
            var lane = Instantiate(lanePrefab, lanesParent);
            lane.transform.localPosition = startPosition.localPosition + Vector3.right * distance * counter;
            lane.SetColor(counter);
            var randomCar = Random.Range(0, 9);
            var randomIndex = Random.Range(0, 2);
            lane.InitializeLane((CarType) randomCar, pool, randomIndex);
            counter++;
        }
    } 
}
