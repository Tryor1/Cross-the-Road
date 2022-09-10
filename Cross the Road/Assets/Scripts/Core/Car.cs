using Data;
using GameData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace Core
{
    public class Car : MonoBehaviour, IPoolable
    {
        [SerializeField]
        private CarData carData;
        [SerializeField]
        private Rigidbody rigidbody;

        private UnityAction<CarType, Car> onWallCollision;

        public void PrepareForActivate()
        {
            rigidbody.velocity = Vector3.zero;
            gameObject.SetActive(true);
        }

        public void PrepareForDeactivate(Transform parent)
        {
            gameObject.SetActive(false);
            transform.SetParent(parent);
        }

        public void OnWallCallisionAddListener(UnityAction<CarType, Car> onWallCollision)
        {
            this.onWallCollision = onWallCollision;
        }

        public float GetSpeed()
        {
            return carData.BaseSpeed;
        }

        public void StartMovement(Vector3 direction, float baseSpeed)
        {
            rigidbody.AddForce(direction * baseSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Wall"))
                onWallCollision.Invoke(carData.CarType, this);
        }
    }
}