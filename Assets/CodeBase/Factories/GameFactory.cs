using System;
using CodeBase.Actors;
using CodeBase.Actors.Fighting;
using CodeBase.Actors.Moving;
using CodeBase.Configs;
using UnityEngine;

namespace CodeBase.Factories
{
    public class GameFactory : MonoBehaviour
    {
        public event Action HeroCreatedEvent;

        [SerializeField] private HeroConfig _heroConfig;
        [SerializeField] private Hero _heroPrefab;
        [Space]
        [SerializeField] private PatrolEnemyConfig _patrolEnemyConfig;
        [SerializeField] private Enemy _patrolEnemyPrefab;
        [Space]
        [SerializeField] private HunterEnemyConfig _hunterEnemyConfig;
        [SerializeField] private Enemy _hunterEnemyPrefab;
        [Space]
        [SerializeField] private ShooterEnemyConfig _shooterEnemyConfig;
        [SerializeField] private Enemy _shooterEnemyPrefab;

        private Hero _hero;

        public Hero Hero => _hero;
        public Hero CreateHero(Vector3 position, Quaternion rotation)
        {
            _hero = Instantiate(_heroPrefab, position, rotation);

            var mover = _hero.GetComponent<IMover>();
            if (mover != null)
                mover.Speed = _heroConfig.Speed;
            
            var health = _hero.GetComponent<Health>();
            if (health != null)
                health.MaxValue = _heroConfig.MaxHp;

            HeroCreatedEvent?.Invoke();
            return _hero;
        }

        public Enemy CreatePatrolEnemy(Vector3 position, Quaternion rotation)
        {
            var enemy = Instantiate(_patrolEnemyPrefab, position, rotation);

            var mover = enemy.GetComponent<IMover>();
            mover.Speed = _patrolEnemyConfig.Speed;
            
            var kamikazeContact = enemy.GetComponent<KamikazeContact>();
            kamikazeContact.ContactDamage = _patrolEnemyConfig.ContactDamage;

            return enemy;
        }
        
        public Enemy CreateHunterEnemy(Vector3 position, Quaternion rotation)
        {
            var enemy = Instantiate(_hunterEnemyPrefab, position, rotation);

            var mover = enemy.GetComponent<IMover>();
            mover.Speed = _hunterEnemyConfig.Speed;
            
            var kamikazeContact = enemy.GetComponent<KamikazeContact>();
            kamikazeContact.ContactDamage = _hunterEnemyConfig.ContactDamage;

            return enemy;
        }
        
        public Enemy CreateShooterEnemy(Vector3 position, Quaternion rotation)
        {
            var enemy = Instantiate(_shooterEnemyPrefab, position, rotation);
            
            var shooting = enemy.GetComponent<Shooting>();
            shooting.AttackCooldown = _shooterEnemyConfig.AttackCooldown;
            shooting.BulletSpeed = _shooterEnemyConfig.BulletSpeed;
            shooting.Damage = _shooterEnemyConfig.Damage;

            return enemy;
        }
    }
}