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
//namespace Generator
//{
//        [Serializable]
//        public class Chunk
//        {
//            public Vector2 ranges;
//            public List<ChunkTemplate> templates;

//            public bool IsBetween(int count)
//            {
//                if ((int)ranges.x <= count && count < (int)ranges.y)
//                    return true;
//                return false;
//            }
//        }
//    public class LaneGenerator : MonoBehaviour
//    {
//        //// Parent  = refka do  parent  = > Dynamic
//        //// Refka do start pos = obiekt Startpos ( spawnpoint_ref
//        //// Counter  int how many lines have i genaraited
//        //// Distance // delta = distance miêdzy kolejnymi laneami // 1.5 u nas. 
//        //// Wygenereowaæ liniiê w pozycji startowerj
//        ///* vector3.Forard * counter . 
//        ///



        
//        [SerializeField]
//        public List<Chunk> chunkes;
//        [SerializeField]
//        private  List<Lane> laneList;
//        [SerializeField]
//        private Transform lanesParent;
//        [SerializeField]
//        private Transform startPos;
//        [SerializeField]
//        private float distance = 1.5f;
//        private int counter;
//        private CarPool<Car> carPool;
//        private ChunkTemplate currentTemplate;
//        private int templateIterator = 0;

//        public void GenerateLevel(CarPool<Car> carPool, int lanesCount)
//        {
//            this.carPool = carPool;
//            for (int i = 0; i < lanesCount; ++i)
//            {
//                var randomCar = Random.Range(0, 4);
//                var spawnPointIndex = Random.Range(0, 2);

//                GenerateLane(carPool, (CarType)randomCar, spawnPointIndex);
//            }
//        }
//        private void OnLaneDespawn()
//        {
//            var randomCar = Random.Range(0, 4);
//            var spawnPointIndex = Random.Range(0, 2);

//            GenerateLane(carPool, (CarType)randomCar, spawnPointIndex);
//        }
//        private Chunk GetChunk()
//        {
//            for (int i = 0; i < chunkes.Count; ++i)
//            {
//                var chunk = chunkes[i];
//                if (chunk.IsBetween(counter))
//                    return chunk;
//            }
//            return chunkes[chunkes.Count - 1];
//        }
//        private ChunkTemplate GetTemplate(Chunk chunk)
//        {
//            var randomTemplate = UnityEngine.Random.Range(0, chunk.templates.Count);
//            return chunk.templates[randomTemplate];
//        }
//        //public void GenerateLane(CarPool<Car> carPool, CarType carType, int spawnPointIndex)
//        //{
//        //    if (templateIterator == currentTemplate.lanes.Count)
//        //    {
//        //        var chunk = GetChunk();
//        //        currentTemplate = GetTemplate(chunk);
//        //        templateIterator = 0;
//        //    }

//        //    var lanePrefab = currentTemplate.lanes[templateIterator];
//        //    templateIterator++;
//        //    var lane = Instantiate(laneList[counter%2], lanesParent);
//        //    lane.transform.position = startPos.position + Vector3.right * distance * counter;
            
//        //    lane.InitializeLane(carPool, carType, spawnPointIndex);
//        //    lane.OnDespawnAddListener(OnLaneDespawn);
//        //    counter++;
//        //}
//        public void GenerateLane(CarPool<Car> carPool, CarType carType, int spawnPointIndex)
//        {
//            if (templateIterator == currentTemplate.lanes.Count)
//            {
//                var chunk = GetChunk();
//                currentTemplate = GetTemplate(chunk);
//                templateIterator = 0;
//            }

//            var lanePrefab = currentTemplate.lanes[templateIterator];
//            templateIterator++;

//            var lane = Instantiate(laneList[counter % 2], lanesParent);
//            lane.transform.position = startPos.position + Vector3.right * distance * counter;            lane.InitializeLane(carPool, carType, spawnPointIndex);
//            lane.OnDespawnAddListener(OnLaneDespawn);
//            counter++;
//        }
//    }


//}

namespace Generator
{
    [Serializable]
    public class Chunk
    {
        public Vector2 ranges;
        public List<ChunkTemplate> templates;

        public bool IsBetween(int count)
        {
            if ((int)ranges.x <= count && count < (int)ranges.y)
                return true;
            return false;
        }
    }

    public class LaneGenerator : MonoBehaviour
    {
        [SerializeField]
        private List<Chunk> chunkes;

        [SerializeField] private Transform lanesParent;
        [SerializeField] private Transform startPos;
        [SerializeField] private float distance = 1.5f;







        private int counter;
        private CarPool<Car> carPool;
        private ChunkTemplate currentTemplate;
        private int templateIterator = 0;



        public void GenerateLevel(CarPool<Car> carPool, int lanesCount)
        {
            this.carPool = carPool;
            var chunk = GetChunk();
            currentTemplate = GetTemplate(chunk);
            for (int i = 0; i < lanesCount; ++i)
            {
                var randomCar = Random.Range(0, 9);
                var spawnPointIndex = Random.Range(0, 2);

                GenerateLane(carPool, (CarType)randomCar, spawnPointIndex);
            }
        }

        private void OnLaneDespawn()
        {
            var randomCar = Random.Range(0, 9);
            var spawnPointIndex = Random.Range(0, 2);

            GenerateLane(carPool, (CarType)randomCar, spawnPointIndex);
        }

        private Chunk GetChunk()
        {
            for (int i = 0; i < chunkes.Count; ++i)
            {
                var chunk = chunkes[i];
                if (chunk.IsBetween(counter))
                    return chunk;
            }
            return chunkes[chunkes.Count - 1];
        }

        private ChunkTemplate GetTemplate(Chunk chunk)
        {
            var randomTemplate = UnityEngine.Random.Range(0, chunk.templates.Count);
            return chunk.templates[randomTemplate];
        }

        public void GenerateLane(CarPool<Car> carPool, CarType carType, int spawnPointIndex)
        {
            if (templateIterator == currentTemplate.lanes.Count)
            {
                var chunk = GetChunk();
                currentTemplate = GetTemplate(chunk);
                templateIterator = 0;
            }

            var lanePrefab = currentTemplate.lanes[templateIterator];
            templateIterator++;

            var lane = Instantiate(lanePrefab, lanesParent);
            lane.transform.position = startPos.position + Vector3.right * distance * counter;

            lane.InitializeLane(carPool, carType, spawnPointIndex);
            lane.OnDespawnAddListener(OnLaneDespawn);
            counter++;
        }
    }
}
