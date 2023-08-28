using CodeBase.Actors.Moving;
using UnityEngine;

namespace CodeBase.Actors.Idling
{
    public class Patrol : MonoBehaviour
    {
        [SerializeField] private Transform[] _points;
        [SerializeField] private float _stoppingDistance = 1;

        private IToPointMover _toPointMover;
        private int _selectedPointId;

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

        private void OnEnable()
        {
            MoveToSelectedPoint();
        }

        private void Update()
        {
            if (!IsTargetReached())
                return;
            
            SelectNextPoint();
            MoveToSelectedPoint();
        }

        private void MoveToSelectedPoint()
        {
            _toPointMover.MoveToPoint(_points[_selectedPointId].position);
        }

        private void SelectNextPoint()
        {
            _selectedPointId = (_selectedPointId < _points.Length - 1)
                ? _selectedPointId + 1 
                : 0;
        }

        private bool IsTargetReached()
        {
            return (_points[_selectedPointId].position - transform.position).sqrMagnitude < Mathf.Pow(_stoppingDistance, 2);
        }
    }
}