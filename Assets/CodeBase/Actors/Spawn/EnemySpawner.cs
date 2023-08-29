using System;
using CodeBase.Factories;
using UnityEngine;

namespace CodeBase.Actors.Spawn
{
    public class EnemySpawner : Spawner
    {
        public override event Action<GameObject> SpawnedEvent;
        
        [SerializeField] private GameFactory _gameFactory;
        [SerializeField] private EnemyType _enemyType;
        
        protected override Color GizmoColor => GetEnemyTypeGizmoColor();

        private void Start() => 
            Spawn();
        
        public override void Spawn()
        {
            var enemy = CreateEnemy();
            if (enemy != null)
                SpawnedEvent?.Invoke(enemy.gameObject);
        }

        private Enemy CreateEnemy()
        {
            return _enemyType switch
            {
                EnemyType.NONE => null,
                EnemyType.PATROL => _gameFactory.CreatePatrolEnemy(transform.position, transform.rotation),
                EnemyType.HUNTER => _gameFactory.CreateHunterEnemy(transform.position, transform.rotation),
                EnemyType.SHOOTER => _gameFactory.CreateShooterEnemy(transform.position, transform.rotation),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private Color GetEnemyTypeGizmoColor()
        {
            return _enemyType switch
            {
                EnemyType.NONE => new Color(1f, 1f, 1f, 0.75f),
                EnemyType.PATROL => new Color(1f, 0.6f, 0f, 0.75f),
                EnemyType.HUNTER => new Color(1f, 0f, 0.6f, 0.75f),
                EnemyType.SHOOTER => new Color(1f, 0f, 0f, 0.75f),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}