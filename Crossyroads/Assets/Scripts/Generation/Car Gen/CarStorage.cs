using System.Collections.Generic;
using Logic;
using Core;
using Data;
using CarPools;
using UnityEngine;
 
namespace SDA.Generation
{
    public class CarStorage : MonoBehaviour
    {
        [SerializeField]
        private Transform storageParent;

        [SerializeField] private Car ambulancePrefab;
        [SerializeField] private Car deliveryPrefab;
        [SerializeField] private Car firetruckPrefab;
        [SerializeField] private Car hatchbackPrefab;
        [SerializeField] private Car policePrefab;
        [SerializeField] private Car sedanPrefab;
        [SerializeField] private Car suvPrefab;
        [SerializeField] private Car truckPrefab;
        [SerializeField] private Car vanPrefab;
        
        private CarPool<Car> carsPool;
        public CarPool<Car> CarsPool => carsPool; //read only

        public void InitializeStorage()
        {
            var sizes = new Dictionary<CarType, int>();
            sizes.Add(CarType.Ambulance, 15);
            sizes.Add(CarType.Delivery, 15);
            sizes.Add(CarType.Firetruck, 15);
            sizes.Add(CarType.Hatchback, 15);
            sizes.Add(CarType.Police, 15);
            sizes.Add(CarType.Sedan, 15);
            sizes.Add(CarType.Suv, 15);
            sizes.Add(CarType.Truck, 15);
            sizes.Add(CarType.Van, 15);
            
            carsPool = new CarPool<Car>(sizes, storageParent);
            InitializePool(CarType.Ambulance, ambulancePrefab);
            InitializePool(CarType.Delivery, deliveryPrefab);
            InitializePool(CarType.Firetruck, firetruckPrefab);
            InitializePool(CarType.Hatchback, hatchbackPrefab);
            InitializePool(CarType.Police, policePrefab);
            InitializePool(CarType.Sedan, sedanPrefab);
            InitializePool(CarType.Suv, suvPrefab);
            InitializePool(CarType.Truck, truckPrefab);
            InitializePool(CarType.Van, vanPrefab);
        }

        private void InitializePool(CarType type, Car prefab)
        {
            for (int i = 0; i < carsPool.GetSize(type); ++i)
            {
                var obj = Instantiate(prefab);
                carsPool.ReturnToPool(type, obj);
            }
        }
    }
}