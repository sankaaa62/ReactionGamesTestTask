using System;
using CodeBase.Factories;
using UnityEngine;

namespace CodeBase.Actors.Spawn
{
    public class HeroSpawner : Spawner
    {
        public override event Action<GameObject> SpawnedEvent;

        [SerializeField] private GameFactory _gameFactory;

        protected override Color GizmoColor => new Color(0f, 0f, 1f, 0.75f);

        private void Start()
        {
            if (IsSpawnOnStart)
                Spawn();
        }

        public override void Spawn()
        {
            var hero = _gameFactory.CreateHero(transform.position, transform.rotation);
            SpawnedEvent?.Invoke(hero.gameObject);
        }
    }
}
