using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Data;
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
     
        
            //0. Wrzu� RB i collider na samoch�d na scenie
            //1. Stw�rz klase samoch�d
            //2. zdefiniuj pole Rigidbody
            //3. Zdefiniuj metod� AddForce i wykorzystaj pobrane Rigidbody
            //4. Spraw aby samoch�d pojecha� w kierunku w kt�rym stoi

            [SerializeField] private SpawnPoint[] spawnPoint;
            [SerializeField] private Transform elo;
            [SerializeField] private CarData[] cars;

            public void SpawnCar()
            {
                var randomIndex = Random.Range(0, cars.Length);
                var randomPoint = Random.Range(0, spawnPoint.Length);

                var carToInstantiate = cars[randomIndex];

                var obj = Instantiate(carToInstantiate.Prefab, spawnPoint[randomPoint].originSpawnPoint.parent, true);
                //obj.StartMovement();
                obj.transform.localPosition = spawnPoint[randomPoint].originSpawnPoint.localPosition;
                obj.transform.localRotation = spawnPoint[randomPoint].originSpawnPoint.localRotation;
                obj.StarMovement(spawnPoint[randomPoint].GetDirection(),carToInstantiate.BaseSpeed);  
                


            }
       




    }
}