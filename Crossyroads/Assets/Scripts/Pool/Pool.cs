using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace Utilities
{

    public class Pool<TPoolable>
        where TPoolable : IPoolable
    {
        private Dictionary<CarType, List<TPoolable>> pooledObjects = new Dictionary<CarType, TPoolable>();
        private Stack<TPoolable> pooledObjects = new Stack<TPoolable>();
        private int size;

        public int Size => size;
        public int Count => pooledObjects.Count;
        // public int Count
        // {
        //     get { return size; }
        // }

        public Pool(List<TPoolable> objectsToPool)
        {
            

            this.size = objectsToPool.Count;
            foreach (TPoolable poolable in objectsToPool)
            {
                pooledObjects.Push(poolable);
            }
        }

        public Pool(int size)
        {
            this.size = size;
        }

        //Instantiate
        public TPoolable GetFromPool()
        {
            if (pooledObjects.Count > 0)
            {
                var obj = pooledObjects.Pop();
                obj.PrepareForActivate();
                return obj;
            }
            return default;
        }

        public bool TryGetFromPool(out TPoolable item)
        {
            item = GetFromPool();
            if (item != null)
                return true;
            return false;
        }

        //Destroy
        public void ReturnToPool(TPoolable car, Transform parent)
        {
            if (pooledObjects.Count <= size)
            {
                car.PrepareForDeactivate(parent);
                pooledObjects.Push(car);
            }
        }

        public bool TryReturnToPool(TPoolable car, Transform parent)
        {
            if (pooledObjects.Count <= size)
            {
                car.PrepareForDeactivate(parent);
                pooledObjects.Push(car);
                return true;
            }

            return false;
        }
    }

}