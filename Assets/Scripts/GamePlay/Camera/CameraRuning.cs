using UnityEngine;

namespace Camera
{
    internal class CameraRuning : MonoBehaviour
    {
        [SerializeField] Transform _cameraTransform;
        [SerializeField] float speed;

        private void FixedUpdate()
        {
            _cameraTransform.transform.position += Vector3.forward * speed * Time.fixedDeltaTime;
        }
    }
}
