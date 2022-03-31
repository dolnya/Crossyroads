using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
namespace Generator
{
    public class CarGenerator : MonoBehaviour
    {
     
        
            //0. Wrzu� RB i collider na samoch�d na scenie
            //1. Stw�rz klase samoch�d
            //2. zdefiniuj pole Rigidbody
            //3. Zdefiniuj metod� AddForce i wykorzystaj pobrane Rigidbody
            //4. Spraw aby samoch�d pojecha� w kierunku w kt�rym stoi

            [SerializeField] private Transform spawnPoint;
            [SerializeField] private CarData[] cars;

            public void SpawnCar()
            {
                var randomIndex = Random.Range(0, cars.Length);
                var carToInstantiate = cars[randomIndex];

                var obj = Instantiate(carToInstantiate.Prefab, spawnPoint.parent, true);
                //obj.StartMovement();
                obj.transform.localPosition = spawnPoint.localPosition;
                obj.transform.localRotation = spawnPoint.localRotation;
                obj.StarMovement(5000);            

            }
        


    }
}