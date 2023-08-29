using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Actors.Moving
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentMover : MonoBehaviour, IDirectedMover, IToPointMover
    {
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
        public float Speed
        {
            get => Agent.speed;
            set => Agent.speed = value;
        }
        public float AngularSpeed
        {
            get => Agent.angularSpeed;
            set => Agent.angularSpeed = value;
        }

        private void Initialize()
        {
            _agent = GetComponent<NavMeshAgent>();
            _isInitialized = true;
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
            Agent.Move(direction * (Speed * Time.deltaTime));
        }

        private void RotateTo(Vector3 direction)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                Quaternion.LookRotation(direction),
                AngularSpeed * Time.deltaTime);
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
