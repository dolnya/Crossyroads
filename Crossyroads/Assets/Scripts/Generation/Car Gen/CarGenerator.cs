using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
namespace Generator
{
    public class CarGenerator : MonoBehaviour
    {
     
        
            //0. Wrzuæ RB i collider na samochód na scenie
            //1. Stwórz klase samochód
            //2. zdefiniuj pole Rigidbody
            //3. Zdefiniuj metodê AddForce i wykorzystaj pobrane Rigidbody
            //4. Spraw aby samochód pojecha³ w kierunku w którym stoi

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