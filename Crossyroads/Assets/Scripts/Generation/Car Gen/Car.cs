using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rg;

    public void StarMovement(int speed)
    {
        rg.AddForce(transform.forward * Time.deltaTime * speed, ForceMode.Impulse);
    }
}
