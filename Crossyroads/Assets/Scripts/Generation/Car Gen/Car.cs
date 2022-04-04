using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rg;

    public void StarMovement(Vector3 direction, float speed)
    {
        rg.AddForce(direction * Time.deltaTime * speed, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "destroy")
            Destroy(gameObject);
    }
}
