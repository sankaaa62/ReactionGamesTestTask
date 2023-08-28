using CodeBase.Actors.Moving;
using UnityEngine;

namespace CodeBase.Actors.Following
{
    public class ChaseToTarget : Follow
    {
        [SerializeField] private float _stoppingDistance = 0;

        private IToPointMover _toPointMover;

        private void Construct()
        {
            _toPointMover = GetComponent<IToPointMover>();
            if (_toPointMover == null) 
                Debug.LogError("The component implementing the interface <IToPointMover> was not found.");
        }

        private void Awake()
        {
            Construct();
        }

        private void Update()
        {
            if (Target == null)
                return;
            
            Chase();
        }

        private void Chase()
        {
            if (!IsTargetReached())
                _toPointMover.MoveToPoint(Target.position);
            else
                _toPointMover.StopMove();
        }

        private bool IsTargetReached()
        {
            return (Target.position - transform.position).sqrMagnitude < Mathf.Pow(_stoppingDistance, 2);
        }
    }
}