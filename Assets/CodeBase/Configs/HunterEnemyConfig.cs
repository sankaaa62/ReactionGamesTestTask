using UnityEngine;

namespace CodeBase.Configs
{
    [CreateAssetMenu(fileName = "HunterEnemyConfig", menuName = "GameConfigs/Enemy/HunterEnemyConfig", order = 52)]
    public class HunterEnemyConfig : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _contactDamage;

        public float Speed => _speed;
        public float ContactDamage => _contactDamage;
    }
}