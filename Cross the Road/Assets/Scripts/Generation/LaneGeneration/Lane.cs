using Core;
using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace Generation
{
    public abstract class Lane : MonoBehaviour
    {
        public abstract void InitializeLane(CarType type, CarPool<Car> pool, int spawnPointIndex, int difficulty);
    } 
}
