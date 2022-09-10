using Core;
using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Generation
{
    public class CarStorage : MonoBehaviour
    {
        [SerializeField]
        private Transform storageParent;

        #region Car Prefabs
        [SerializeField]
        private Car ambulancePrefab;
        [SerializeField]
        private Car deliveryPrefab;
        [SerializeField]
        private Car firetruckPrefab;
        [SerializeField]
        private Car hatchbackSportsPrefab;
        [SerializeField]
        private Car policePrefab;
        [SerializeField]
        private Car sedanPrefab;
        [SerializeField]
        private Car suvPrefab;
        [SerializeField]
        private Car truckPrefab;
        [SerializeField]
        private Car vanPrefab; 
        #endregion

        private CarPool<Car> carsPool;
        public CarPool<Car> CarsPool => carsPool;

        public void InitializeStorage()
        {
            var sizes = new Dictionary<CarType, int>();

            #region Car Type Sizes
            sizes.Add(CarType.Ambulance, 15);
            sizes.Add(CarType.Delivery, 15);
            sizes.Add(CarType.Firetruck, 15);
            sizes.Add(CarType.HatchbackSports, 15);
            sizes.Add(CarType.Police, 15);
            sizes.Add(CarType.Sedan, 15);
            sizes.Add(CarType.Suv, 15);
            sizes.Add(CarType.Truck, 15);
            sizes.Add(CarType.Van, 15); 
            #endregion

            carsPool = new CarPool<Car>(sizes, storageParent);

            #region Filling Pools
            FillPool(CarType.Ambulance, ambulancePrefab);
            FillPool(CarType.Delivery, deliveryPrefab);
            FillPool(CarType.Firetruck, firetruckPrefab);
            FillPool(CarType.HatchbackSports, hatchbackSportsPrefab);
            FillPool(CarType.Police, policePrefab);
            FillPool(CarType.Sedan, sedanPrefab);
            FillPool(CarType.Suv, suvPrefab);
            FillPool(CarType.Truck, truckPrefab);
            FillPool(CarType.Van, vanPrefab); 
            #endregion
        }

        private void FillPool(CarType type, Car prefab)
        {
            for(int i=0; i<carsPool.GetSize(type); i++)
            {
                var obj = Instantiate(prefab);
                carsPool.ReturnToPool(type, obj);
            }
        }
    } 
}
