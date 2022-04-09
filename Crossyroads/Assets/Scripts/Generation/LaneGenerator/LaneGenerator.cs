using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Data;
using Generator;
using CarPools;
using Core;
using LaneGen;
using Chunk;
using UnityEngine.Events;
using Random = UnityEngine.Random;
namespace Generator
{

    public class LaneGenerator : MonoBehaviour
    {
        //// Parent  = refka do  parent  = > Dynamic
        //// Refka do start pos = obiekt Startpos ( spawnpoint_ref
        //// Counter  int how many lines have i genaraited
        //// Distance // delta = distance miêdzy kolejnymi laneami // 1.5 u nas. 
        //// Wygenereowaæ liniiê w pozycji startowerj
        ///* vector3.Forard * counter . 
        ///



        [Serializable]
        public class Chunck
        {
            public Vector2 ranges;
            public List<ChunkTemplate> chunchTemplate;
            public bool IsBetween(int count)
            {
                if (ranges.x < count && count <= ranges.y)
                    return true;
                return false;
            }
        }

          
        [SerializeField]
        private Lane lanePrefab;

        [SerializeField]

        public List<Chunck> chunches;
        
        [SerializeField]
        private  List<Lane> laneList;
        [SerializeField]
        private Transform lanesParent;
        [SerializeField]
        private Transform startPos;
        [SerializeField]
        private float distance = 1.5f;
        private int counter;
        private CarPool<Car> carPool;

        public void GenerateLevel(CarPool<Car> carPool, int lanesCount)
        {
            this.carPool = carPool;
            for (int i = 0; i < lanesCount; ++i)
            {
                var randomCar = Random.Range(0, 9);
                var spawnPointIndex = Random.Range(0, 2);

                GenerateLane(carPool, (CarType)randomCar, spawnPointIndex);
            }
        }

        //public void GenerateLane()
        //{
        //    var lane = Instantiate(lanePrefab, lanesParent);
        //    lane.transform.position = startPos.position + Vector3.right * distance * counter;
        //    //lane.SetColor(counter);
        //    //lane.InitializeLane();
        //    counter++;
        //}
        //public void GenerateLaneList()
        //{
            
        //    var lane = Instantiate(laneList[counter%2], lanesParent);
        //    lane.transform.position = startPos.position + Vector3.right * distance * counter;
        //    lane.InitializeLane();
        //    //lane.SetColor(counter); 
        //    //lane.InitializeLane();
        //    counter++;
        //}
        //public void GenerateLevelList(int lanesCount)
        //        {
        //            for (int i = 0; i < lanesCount; ++i)
        //            {
        //                GenerateLaneList();

        //            }
        //        }
        private void OnLaneDespawn()
        {
            var randomCar = Random.Range(0, 9);
            var spawnPointIndex = Random.Range(0, 2);

            GenerateLane(carPool, (CarType)randomCar, spawnPointIndex);
        }
        public void GenerateLane(CarPool<Car> carPool, CarType carType, int spawnPointIndex)
        {
            var lane = Instantiate(laneList[counter%2], lanesParent);
            lane.transform.position = startPos.position + Vector3.right * distance * counter;
            
            lane.InitializeLane(carPool, carType, spawnPointIndex);
            lane.OnDespawnAddListener(OnLaneDespawn);
            counter++;
        }
        

        //private void GetChunk()
        //{
        //    for (int i = 0; i < )
        //}    
    }

}
    

