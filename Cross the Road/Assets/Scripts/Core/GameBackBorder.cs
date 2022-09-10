using Generation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Core
{
    public class GameBackBorder : MonoBehaviour
    {
        [SerializeField]
        LaneGenerator laneGenerator;
        [SerializeField]
        CarStorage carStorage;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Lane"))
            {
                Destroy(other.gameObject);
                laneGenerator.GenerateLane(carStorage.CarsPool);
            }
        }
    } 
}
