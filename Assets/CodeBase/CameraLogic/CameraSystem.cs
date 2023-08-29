using Cinemachine;
using CodeBase.Factories;
using UnityEngine;

namespace CodeBase.CameraLogic
{
    public class CameraSystem : MonoBehaviour
    {
        [SerializeField] private GameFactory _gameFactory;
        [SerializeField] private CinemachineVirtualCamera _camera;

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
            _camera.Follow = _gameFactory.Hero.transform;
        }
    }
}
