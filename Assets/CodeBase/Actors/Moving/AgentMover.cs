using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Actors.Moving
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentMover : MonoBehaviour, IMover, IToPointMover
    {
        [SerializeField] private float _speed = 8;
        [SerializeField] private float _angularSpeed = 360;

        private NavMeshAgent _agent;
        private Vector3 _velocity;
        private bool _isInitialized;

        private NavMeshAgent Agent
        {
            get
            {
                if (!_isInitialized)
                    Initialize();
                
                return _agent;
            }
        }
        
        private void Initialize()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void OnEnable()
        {
            Agent.enabled = true;
        }

        private void OnDisable()
        {
            Agent.enabled = false;
        }

        public void Move(Vector3 direction)
        {
            if (direction == Vector3.zero)
                return;

            RotateTo(direction);

            _velocity = direction * _speed;
            Agent.Move(_velocity * Time.deltaTime);
        }

        private void RotateTo(Vector3 direction)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                Quaternion.LookRotation(direction),
                _angularSpeed * Time.deltaTime);
        }

        public void MoveToPoint(Vector3 targetPoint)
        {
            if (Agent == null)
                return;
            
            Agent.destination = targetPoint;
        }

        public void StopMove()
        {
            Agent.destination = transform.position;
        }
    }
}
