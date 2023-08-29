using CodeBase.Actors.Fighting;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class HealthMonitor : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private Health _health;

        public void Initialize(Health health)
        {
            _health = health;
            _health.HealthValueChangedEvent += OnHealthValueChanged;
        }

        public void OnDestroy()
        {
            if (_health != null)
                _health.HealthValueChangedEvent -= OnHealthValueChanged;
        }

        private void OnHealthValueChanged(float value)
        {
            RefreshView();
        }

        private void RefreshView()
        {
            _slider.value = _health.CurrentValue / _health.MaxValue;
        }
    }
}