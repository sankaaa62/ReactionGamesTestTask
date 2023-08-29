using UnityEngine;

namespace CodeBase.Actors.Following
{
    public class ToTargetRotator : Follower
    {
        [SerializeField] private float _rotationSpeed = 360f;
        
        private Vector3 _direction;
        private Quaternion _toTargetRotation;

        public float RotationSpeed
        {
            get => _rotationSpeed;
            set => _rotationSpeed = value;
        }

        private void Update()
        {
            if (HasTarget())
                UpdateRotation();
        }

        private void UpdateRotation()
        {
            UpdateToTargetRotation();
            SmoothRotate();
        }

        private void SmoothRotate()
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                _toTargetRotation,
                _rotationSpeed * Time.deltaTime);
        }

        private void UpdateToTargetRotation()
        {
            _direction = Target.position - transform.position;
            _direction.y = 0;

            _toTargetRotation = Quaternion.LookRotation(_direction);
        }

        private bool HasTarget()
        {
            return Target != null;
        }
    }
}