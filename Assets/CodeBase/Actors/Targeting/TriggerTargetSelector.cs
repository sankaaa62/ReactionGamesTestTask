using System;
using CodeBase.Utils;
using UnityEngine;

namespace CodeBase.Actors.Targeting
{
    public class TriggerTargetSelector : TargetSelector
    {
        public override event Action TargetChangedEvent;
        
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private FriendOrFoeSystem _friendOrFoeSystem;
        
        private Transform _target;

        public override Transform Target
        {
            get => _target;
            protected set
            {
                if (Equals(_target, value))
                    return;
                
                _target = value;
                TargetChangedEvent?.Invoke();
            }
        }
        
        private void Awake()
        {
            _triggerObserver.TriggerEnterEvent += OnTriggerEnter;
            _triggerObserver.TriggerExitEvent += OnTriggerExit;
        }

        private void OnDestroy()
        {
            _triggerObserver.TriggerEnterEvent -= OnTriggerEnter;
            _triggerObserver.TriggerExitEvent -= OnTriggerExit;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (_friendOrFoeSystem.IsFoe(other.transform)) 
                Target = other.transform;
        }

        private void OnTriggerExit(Collider other)
        {
            if (Equals(Target, other.transform)) 
                Target = null;
        }
    }
}