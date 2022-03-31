using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generator;
public class Lane : MonoBehaviour
{
    [SerializeField]
    private CarGenerator carGenerator;

    public void InitializeLane()
    {
        StartCoroutine(GenerateCar(3f));
    }

    private IEnumerator GenerateCar(float timeBetweenSpawns)
    {
        while (true)
        {
            carGenerator.SpawnCar();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

}
