using CodeBase.Actors.Moving;
using UnityEngine;

namespace CodeBase.Actors.Following
{
    public class TargetChaser : Follower
    {
        [SerializeField] private float _stoppingDistance = 0;

        private IToPointMover _toPointMover;

        private void Construct()
        {
            _toPointMover = GetComponent<IToPointMover>();
            if (_toPointMover == null) 
                Debug.LogError("ToPointMover was not found.");
        }

        private void Awake()
        {
            Construct();
        }

        private void Update()
        {
            if (HasTarget())
                Chase();
        }

        private void Chase()
        {
            if (!IsTargetReached())
                _toPointMover.MoveToPoint(Target.position);
            else
                _toPointMover.StopMove();
        }

        private bool HasTarget()
        {
            return Target != null;
        }

        private bool IsTargetReached()
        {
            return (Target.position - transform.position).sqrMagnitude < Mathf.Pow(_stoppingDistance, 2);
        }
    }
}