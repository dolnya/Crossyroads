using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using UnityEngine.Events;
using CarPools;

namespace Core
{
    public class Car : MonoBehaviour, IPoolable
    {
        [SerializeField] private CarData carData;
        [SerializeField] private Rigidbody rigidbodyCar;

        private UnityAction<Car> onWallHit;

        public void StartMovement(Vector3 direction, float speed)
        {
            rigidbodyCar.AddForce(direction * (speed * Time.fixedDeltaTime), ForceMode.Impulse);
        }

        public float GetSpeed()
        {
            return carData.BaseSpeed;
        }
        public void OnWallHitAddListener(UnityAction<Car> onWallHit)
        {
            this.onWallHit = onWallHit;
        }
        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.CompareTag("Wall"))
        //        onWallHit.Invoke(this);
        //}

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Wall")
                //Destroy(gameObject);
                onWallHit.Invoke(this);
        }

        public void PrepareForActivate()
        {
            rigidbodyCar.velocity = Vector3.zero;
            gameObject.SetActive(true);
        }

        public void PrepareForDeactivate(Transform parent)
        {
            gameObject.SetActive(false);
            transform.SetParent(parent);
        }
    }
}
