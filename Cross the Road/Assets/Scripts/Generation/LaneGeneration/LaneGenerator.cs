using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        private float distance;

        private int counter;
        /*
        var startLane = Instantiate(safeLanePrefab, lanesParent);
        startLane.transform.localPosition = startPosition.localPosition + Vector3.right* distance * -1;
        */
        public void GenerateLevel(int lanesCount)
        {
            for(int i=0; i<lanesCount; i++)
            {
                GenerateLane();
            }
        }

        public void GenerateLane()
        {
            var lane = Instantiate(lanePrefab, lanesParent);
            lane.transform.localPosition = startPosition.localPosition + Vector3.right * distance * counter;
            lane.SetColor(counter);
            lane.InitializeLane();
            counter++;
        }
    } 
}
