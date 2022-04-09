using UnityEngine;
using UnityEditor;
using DG.Tweening;


namespace Camera
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private float speedBase = 1f;
        [SerializeField]
        private float speedCatch = 3f;
        [SerializeField]
        private float distance = 10f;
        [SerializeField]
        private float transitionSpeed = 0.2f;
        [SerializeField]
        private Transform playerTransform;
        [SerializeField]
        private Transform cameraRefPoint;
        public Vector3 originalPos;

        private float disanceToEgde;







        public void UpdateMovement()
        {
            transform.position += Vector3.right * Time.deltaTime * speedBase;
            CalculateDistance();
            if (disanceToEgde >= distance)
            {
                
                transform.position += Vector3.right * Time.deltaTime * Mathf.Lerp(speedBase, speedCatch, transitionSpeed); ;
            }
        }

        public void RestetPosition()
        {
            gameObject.transform.position = originalPos;
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(cameraRefPoint.position, playerTransform.position);
            
            Handles.Label(cameraRefPoint.position, $"Distance to Edge = {disanceToEgde}");
        }

        private void CalculateDistance()
        {
            disanceToEgde = playerTransform.position.x - cameraRefPoint.position.x;
        }



    }
}