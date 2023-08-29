using System;
using UnityEngine;

namespace CodeBase.Actors.Fighting
{
    public class Health : MonoBehaviour, IDamageTaker
    {
        public event Action<float> HealthValueChangedEvent;
        
        [SerializeField] private float _maxValue;

        private float _currentValue;

        public float MaxValue
        {
            get => _maxValue;
            set => _maxValue = value;
        }
        
        public float CurrentValue
        {
            get => _currentValue;
            set
            {
                var clampedValue = Mathf.Clamp(value, 0f, MaxValue);
                
                _currentValue = clampedValue;
                HealthValueChangedEvent?.Invoke(_currentValue);
            }
        }

        private void Start()
        {
            CurrentValue = MaxValue;
        }

        public void TakeDamage(float damage)
        {
            CurrentValue -= damage;
            Debug.Log(gameObject.name + " TakeDamage = " + damage);
        }
    }
    
    
}