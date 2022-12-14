using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Utils
{
    public class CarPool<TPoolable>
        where TPoolable : IPoolable
    {
        private Dictionary<CarType, Stack<TPoolable>> pooledObjects = new Dictionary<CarType, Stack<TPoolable>>();
 
        private Dictionary<CarType, int> size = new Dictionary<CarType, int>();
        
        private Transform poolParent;
        
        public int GetSize(CarType type)
        {
            return size[type];
        }

        public CarPool(Dictionary<CarType, int> sizes, Transform poolParent)
        {
            this.poolParent = poolParent;
            foreach (KeyValuePair<CarType, int> kvp in sizes)
            {
                size.Add(kvp.Key, kvp.Value);
                var objectsStack = new Stack<TPoolable>();
                pooledObjects.Add(kvp.Key, objectsStack);
            }
        }
        
        public CarPool(Dictionary<CarType, List<TPoolable>> objectsToPool, Transform poolParent)
        {
            this.poolParent = poolParent;
            foreach (KeyValuePair<CarType, List<TPoolable>> kvp in objectsToPool)
            {
                size.Add(kvp.Key, kvp.Value.Count);
                var objectsStack = new Stack<TPoolable>();
                foreach (TPoolable car in kvp.Value)
                {
                    objectsStack.Push(car);
                }
                pooledObjects.Add(kvp.Key, objectsStack);
            }
        }

        //Instantiate
        public TPoolable GetFromPool(CarType type)
        {
            if (pooledObjects[type].Count > 0)
            {
                var obj = pooledObjects[type].Pop();
                obj.PrepareForActivate();
                return obj;
            }

            return default;
        }

        public bool TryGetFromPool(CarType type, out TPoolable car)
        {
            car = GetFromPool(type);
            if (car != null)
                return true;
            return false;
        }

        //Destroy
        public void ReturnToPool(CarType type, TPoolable car)
        {
            if (pooledObjects[type].Count <= size[type])
            {
                car.PrepareForDeactivate(poolParent);
                pooledObjects[type].Push(car);
            }
        }

        public bool TryReturnToPool(CarType type, TPoolable car)
        {
            if (pooledObjects[type].Count <= size[type])
            {
                car.PrepareForDeactivate(poolParent);
                pooledObjects[type].Push(car);
                return true;
            }

            return false;
        }
    }
}