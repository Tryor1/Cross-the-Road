using GameData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generation
{
    public class CarGenerator : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private CarData[] cars;

        public void SpawnCar()
        {
            var randomIndex = Random.Range(0, cars.Length);
            var carToInstantiate = cars[randomIndex];

            var obj = Instantiate(carToInstantiate.Prefab);
            obj.transform.SetParent(spawnPoint.parent);
            obj.transform.localPosition = spawnPoint.localPosition;
            obj.transform.localRotation = spawnPoint.localRotation;
        }
    } 
}
