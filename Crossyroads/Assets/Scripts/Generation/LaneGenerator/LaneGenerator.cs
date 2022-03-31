using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        [SerializeField]
        private Lane lanePrefab;
        [SerializeField]
        private  List<Lane> laneList;
        [SerializeField]
        private Transform lanesParent;
        [SerializeField]
        private Transform startPos;
        [SerializeField]
        private float distance = 1.5f;
        private int counter;

        public void GenerateLevel(int lanesCount)
        {
            for (int i = 0; i < lanesCount; ++i)
            {
                GenerateLane();
            }
        }

        public void GenerateLane()
        {
            var lane = Instantiate(lanePrefab, lanesParent);
            lane.transform.position = startPos.position + Vector3.right * distance * counter;
            //lane.SetColor(counter);
            //lane.InitializeLane();
            counter++;
        }
        public void GenerateLaneList()
        {
            
            var lane = Instantiate(laneList[counter%2], lanesParent);
            lane.transform.position = startPos.position + Vector3.right * distance * counter;
            lane.InitializeLane();
            //lane.SetColor(counter); 
            //lane.InitializeLane();
            counter++;
        }
        public void GenerateLevelList(int lanesCount)
        {
            for (int i = 0; i < lanesCount; ++i)
            {
                GenerateLaneList();

            }
        }


    }

}
    

