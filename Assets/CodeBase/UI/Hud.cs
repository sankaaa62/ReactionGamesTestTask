using CodeBase.Actors.Fighting;
using CodeBase.Factories;
using UnityEngine;

namespace CodeBase.UI
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] private GameFactory _gameFactory;
        [SerializeField] private HealthMonitor _healthMonitor;

        private void Awake()
        {
            if (_gameFactory.Hero != null)
                SetPlayer();
            
            _gameFactory.HeroCreatedEvent += OnHeroCreated;
        }

        private void OnHeroCreated()
        {
            SetPlayer();
        }

        private void SetPlayer()
        {
            _healthMonitor.Initialize(_gameFactory.Hero.GetComponent<Health>());
        }
    }
}