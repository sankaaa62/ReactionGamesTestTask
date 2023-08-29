using System;
using CodeBase.Utils;
using UnityEngine;

namespace CodeBase.Actors.Targeting
{
    public class TriggerTargetSelector : TargetSelector
    {
        public override event Action TargetChangedEvent;
        
        [SerializeField] private TriggerObserver _targetTrigger;
        [SerializeField] private FriendOrFoeSystem _friendOrFoeSystem;
        
        private Transform _target;

        public override Transform Target
        {
            get => _target;
            protected set
            {
                if (_target == value)
                    return;
                
                _target = value;
                TargetChangedEvent?.Invoke();
            }
        }
        
        private void Awake()
        {
            _targetTrigger.TriggerEnterEvent += OnTargetTriggerEnter;
            _targetTrigger.TriggerExitEvent += OnTargetTriggerExit;
        }

        private void OnDestroy()
        {
            _targetTrigger.TriggerEnterEvent -= OnTargetTriggerEnter;
            _targetTrigger.TriggerExitEvent -= OnTargetTriggerExit;
        }
        
        private void OnTargetTriggerEnter(Collider other)
        {
            if (_friendOrFoeSystem.IsFoe(other.transform)) 
                Target = other.transform;
        }

        private void OnTargetTriggerExit(Collider other)
        {
            if (Equals(Target, other.transform)) 
                Target = null;
        }
    }
}