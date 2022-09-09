using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(menuName = "Cross/Car/New Car")]
    public class CarData : ScriptableObject
    {
        [SerializeField]
        private Car prefab;
        [SerializeField]
        private float baseSpeed;

        public Car Prefab => prefab;
        public float BaseSpeed => baseSpeed;
    } 
}
