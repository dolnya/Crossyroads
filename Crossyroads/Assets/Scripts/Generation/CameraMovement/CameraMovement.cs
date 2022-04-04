using UnityEngine;

namespace Core
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private float speed = 10f;
        
        public void UpdateMovement()
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
    }
}