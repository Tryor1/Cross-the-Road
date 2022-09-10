using UnityEngine;

namespace Core
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private float speed = 1.8f;

        public void MoveCamera()
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
    } 
}
