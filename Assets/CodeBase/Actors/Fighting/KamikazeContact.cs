using CodeBase.Actors.Targeting;
using CodeBase.Utils;
using UnityEngine;

namespace CodeBase.Actors.Fighting
{
    public class KamikazeContact : MonoBehaviour
    {
        [SerializeField] private FriendOrFoeSystem _friendOrFoeSystem;
        [SerializeField] private TriggerObserver _contactTrigger;
        [SerializeField] private Death _death;
        
        [Space]
        [SerializeField] private float _contactDamage;

        private bool _isTriggered;

        public float ContactDamage
        {
            get => _contactDamage;
            set => _contactDamage = value;
        }

        private void Awake()
        {
            _contactTrigger.TriggerEnterEvent += OnContactTriggerEnter;
        }

        private void OnDestroy()
        {
            _contactTrigger.TriggerEnterEvent -= OnContactTriggerEnter;
        }
        
        private void OnContactTriggerEnter(Collider other)
        {
            if (_isTriggered)
                return;
            
            if (!_friendOrFoeSystem.IsFoe(other.transform))
                return;
            
            if (!other.TryGetComponent<IDamageTaker>(out var damageTaker))
                return;

            _isTriggered = true;
            
            damageTaker.TakeDamage(ContactDamage);
            _death.Die();
        }
    }
}