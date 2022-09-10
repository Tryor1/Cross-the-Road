using Core;
using Data;
using GameData;
using System;
using UnityEngine;
using Utils;
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
        [SerializeField]
        private SpawnPoint[] spawnPoints;

        private CarType carType;
        private CarPool<Car> pool;
        private int spawnPointIndex;

        public void InitializeGenerator(CarType type, CarPool<Car> pool, int index)
        {
            carType = type;
            this.pool = pool;
            spawnPointIndex = index;
        }

        public void ReturnToPool(CarType type,Car car)
        {
            pool.ReturnToPool(type, car);
        }

        public void SpawnCar(Transform parent)
        {
            var obj = pool.GetFromPool(carType);
            obj.OnWallCallisionAddListener(ReturnToPool);
            obj.transform.SetParent(parent);
            obj.transform.position = spawnPoints[spawnPointIndex].spawnPositionTransform.position;
            obj.transform.rotation = spawnPoints[spawnPointIndex].spawnPositionTransform.rotation;
            obj.StartMovement(spawnPoints[spawnPointIndex].GetDirection(), obj.GetSpeed());
        }
    } 
}
