using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CarPools;
using Core;
namespace Data
{ 
    [CreateAssetMenu(menuName ="Crossy/Car/NewCar")]
    public class CarData : ScriptableObject
    {
    [SerializeField] private Car prefab;
    [SerializeField] private float baseSpeed;

    public Car Prefab => prefab;
        public float BaseSpeed
        {
            get
            {
                return baseSpeed;
            }
        }
    }
}
