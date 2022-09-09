using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Car : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody rigidbody;

        public void StartMovement(Vector3 direction, float baseSpeed)
        {
            rigidbody.AddForce(direction * baseSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
        }
    }
}