using UnityEngine;

namespace Camera
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private float speed = 10f;


        public Vector3 originalPos;
        
        

        public void UpdateMovement()
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }

        public void RestetPosition()
        {
            gameObject.transform.position = originalPos;
        }
    }
}