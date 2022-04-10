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
        private UnityAction onDespawn;
        public void InitializeLane(CarPool<Car> pool, CarType type, int spawnPointIndex)
        {
            carGenerator.InitializeGenerator(pool, type, spawnPointIndex);
            var time = Random.Range(2f, 10f);
            StartCoroutine(GenerateCar(time));
        }


        private IEnumerator GenerateCar(float timeBetweenSpawns)
        {
            while (true)
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
            if (other.CompareTag("Wall"))
            {
                StopAllCoroutines();
                carGenerator.DespawnCars();
                onDespawn.Invoke();
                Destroy(this.gameObject);
            }
        }

    }

}