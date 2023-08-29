using System;
using UnityEngine;

namespace CodeBase.Actors.Fighting
{
    public class HeroDeath : Death
    {
        public override event Action DiedEvent;
        
        [SerializeField] private Health _health;

        private void Awake()
        {
            _health.HealthValueChangedEvent += OnHealthChanged;
        }

        private void OnDestroy()
        {
            _health.HealthValueChangedEvent += OnHealthChanged;
        }

        private void OnHealthChanged(float value)
        {
            if (value <= 0)
                Die();
        }

        public override void Die()
        {
            DiedEvent?.Invoke();
            Destroy(gameObject);
        }
    }
}