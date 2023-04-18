using UnityEngine;

namespace CameraDev
{
    internal class CameraRuning : MonoBehaviour
    {
        [SerializeField] Transform _target;
        [SerializeField] Transform _camera;
        [SerializeField] float _distanceFollow;
        [SerializeField] float _speed;
        Vector3 offset;

        private void FixedUpdate()
        {
            Following();
        }

        private void Following()
        {
            if (CheckFollow() == false) return;
            offset = GetObsetFollow();
            transform.position = Vector3.MoveTowards(transform.position, offset, _speed*Time.fixedDeltaTime);
        }

        private bool CheckFollow()
        {
            return Mathf.Abs(_camera.position.z - _target.position.z) > _distanceFollow;
        }

        private Vector3 GetObsetFollow()
        {
            return new Vector3(_camera.position.x, _camera.position.y, _target.position.z - _distanceFollow);
        }

    }
}
