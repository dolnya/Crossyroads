using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core
{
    public class PointsSystem
    {
        private int currentScore;
        public int CurrentScore => currentScore;

        public void AddPoint()
        {
            currentScore++;
        }
    }
}
