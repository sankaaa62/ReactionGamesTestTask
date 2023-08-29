using UnityEngine;

namespace CodeBase.Configs
{
    [CreateAssetMenu(fileName = "ShooterEnemyConfig", menuName = "GameConfigs/Enemy/ShooterEnemyConfig", order = 52)]
    public class ShooterEnemyConfig : ScriptableObject
    {
        [SerializeField] private float _attackCooldown;
        [SerializeField] private float _damage;
        [SerializeField] private float _bulletSpeed;

        public float AttackCooldown => _attackCooldown;
        public float Damage => _damage;
        public float BulletSpeed => _bulletSpeed;
    }
}