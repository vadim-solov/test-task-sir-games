using UnityEngine;

namespace Game.Scripts
{
    public class CameraFollowing : MonoBehaviour
    {
        private Transform _targetTransform;
        private Vector3 _targetStartPosition;

        private const float FollowSpeed = 20f;
        private const float CameraHeight = 30f;

        public void Init(Transform targetTransform)
        {
            _targetTransform = targetTransform;
            _targetStartPosition = targetTransform.position;
        }

        private void LateUpdate()
        {
            SetRotation();
            SetPosition();
        }

        private void SetRotation()
        {
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }

        private void SetPosition()
        {
            Vector3 targetPosition = new Vector3(_targetStartPosition.x, CameraHeight, _targetTransform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, FollowSpeed * Time.deltaTime);
        }
    }
}
