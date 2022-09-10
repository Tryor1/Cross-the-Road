using Data;
using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(menuName = "Cross/Car/New Car")]
    public class CarData : ScriptableObject
    {
        [SerializeField]
        private float baseSpeed;
        [SerializeField]
        CarType carType;

        public CarType CarType => carType;
        public float BaseSpeed => baseSpeed;
    } 
}