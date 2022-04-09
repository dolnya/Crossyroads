using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generator;
using CarPools;
using Core;
using Data;
using UnityEngine.Events;
namespace LaneGen
{

    public class Lane : MonoBehaviour
    {
        [SerializeField]
        private CarGenerator carGenerator;

        [SerializeReference]
        bool SpawnCars = true;
        private UnityAction onDespawn;
        public void InitializeLane(CarPool<Car> pool, CarType type, int spawnPointIndex)
        {
            
            
            carGenerator.InitializeGenerator(pool, type, spawnPointIndex);
            StartCoroutine(GenerateCar(Random.Range(1f,5f)));
        }


        private IEnumerator GenerateCar(float timeBetweenSpawns)
        {
            while (SpawnCars)
            {
                carGenerator.SpawnCar(transform.parent);
                yield return new WaitForSeconds(timeBetweenSpawns);
            }
        }
        public void OnDespawnAddListener(UnityAction callback)
        {
            onDespawn = callback;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Wall")
            {
                StopAllCoroutines();
                carGenerator.DespawnCars();
                onDespawn.Invoke();
                Destroy(this.gameObject);
            }
        }

    }

}