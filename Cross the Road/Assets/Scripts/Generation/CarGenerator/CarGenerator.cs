using GameData;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Generation
{
    public enum Direction
    {
        Forward,
        Backward,
    }

    [Serializable]
    public class SpawnPoint
    {
        public Transform spawnPositionTransform;
        public Direction direction;

        public Vector3 GetDirection()
        {
            if (direction == Direction.Forward)
                return Vector3.forward;
            else
                return Vector3.back;
        }
    }
    public class CarGenerator : MonoBehaviour
    {
        [SerializeField] private SpawnPoint[] spawnPoints;
        [SerializeField] private CarData[] cars;

        public void SpawnCar(Transform parent)
        {
            var randomIndex = Random.Range(0, cars.Length);
            var randomSpawn = Random.Range(0, spawnPoints.Length);
            var carToInstantiate = cars[randomIndex];

            var obj = Instantiate(carToInstantiate.Prefab);
            obj.transform.SetParent(parent);
            obj.StartMovement(spawnPoints[randomSpawn].GetDirection(), carToInstantiate.BaseSpeed);
            obj.transform.position = spawnPoints[randomSpawn].spawnPositionTransform.position;
            obj.transform.rotation = spawnPoints[randomSpawn].spawnPositionTransform.rotation;
        }
    } 
}
