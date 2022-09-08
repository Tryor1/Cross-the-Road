using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(menuName = "Cross/Car/New Car")]
    public class CarData : ScriptableObject
    {
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private float baseSpeed;

        public GameObject Prefab => prefab;
        public float BaseSpeed => baseSpeed;
    } 
}
