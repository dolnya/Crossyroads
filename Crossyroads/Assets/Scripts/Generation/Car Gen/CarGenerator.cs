using System.Collections;
using System.Collections.Generic;
using System;
using Core;
using UnityEngine;
using Data;
using CarPools;
using Random = UnityEngine.Random;
namespace Generator
{
    public enum Direction
    {
        Forward,
        Backward
    }

    [Serializable]
    public class SpawnPoint
    {
        public Transform originSpawnPoint;
        public Direction direction;

        public Vector3 GetDirection()
        {
            if (direction == Direction.Forward)
            {
                return Vector3.forward;
            }
            else 
            
                return Vector3.back;
            
                
            
        }
    }
    public class CarGenerator : MonoBehaviour
    {
     
        
            //0. Wrzuæ RB i collider na samochód na scenie
            //1. Stwórz klase samochód
            //2. zdefiniuj pole Rigidbody
            //3. Zdefiniuj metodê AddForce i wykorzystaj pobrane Rigidbody
            //4. Spraw aby samochód pojecha³ w kierunku w którym stoi

        [SerializeField] private SpawnPoint[] spawnPoint;
        [SerializeField] private Transform elo;
        [SerializeField] private CarData[] cars;

        private CarPool<Car> pool;
        private CarType typeToSpawn;
        private int spawnPointIndex;
        private List<Car> spawnedCars = new List<Car>();
        //public void SpawnCar()
        //    {
        //        var randomIndex = Random.Range(0, cars.Length);
        //        var randomPoint = Random.Range(0, spawnPoint.Length);

        //        var carToInstantiate = cars[randomIndex];

        //        var obj = Instantiate(carToInstantiate.Prefab, spawnPoint[randomPoint].originSpawnPoint.parent, true);
        //        //obj.StartMovement();
        //        obj.transform.localPosition = spawnPoint[randomPoint].originSpawnPoint.localPosition;
        //        obj.transform.localRotation = spawnPoint[randomPoint].originSpawnPoint.localRotation;
        //        obj.StartMovement(spawnPoint[randomPoint].GetDirection(),carToInstantiate.BaseSpeed);  



        //    }
        public void InitializeGenerator(CarPool<Car> pool, CarType type, int spawnIndex)
        {
            this.pool = pool;
            typeToSpawn = type;
            spawnPointIndex = spawnIndex;
        }
        private void ReturnToPool(Car car)
        {
            spawnedCars.Remove(car);
            pool.ReturnToPool(typeToSpawn, car);
        }
        public void SpawnCar(Transform parent)
        {
            var obj = pool.GetFromPool(typeToSpawn);
            obj.transform.SetParent(parent);
            obj.transform.position = spawnPoint[spawnPointIndex].originSpawnPoint.position;
            obj.transform.rotation = spawnPoint[spawnPointIndex].originSpawnPoint.rotation;
            obj.OnWallHitAddListener(ReturnToPool);
            obj.StartMovement(spawnPoint[spawnPointIndex].GetDirection(), obj.GetSpeed());
            spawnedCars.Add(obj);

        }



        public void DespawnCars()
        {
            for (int i = 0; i < spawnedCars.Count; ++i)
            {
                pool.ReturnToPool(typeToSpawn, spawnedCars[i]);
            }
            spawnedCars.Clear();
        }
    }
}