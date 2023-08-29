using UnityEngine;

namespace CodeBase.Configs
{
    [CreateAssetMenu(fileName = "PatrolEnemyConfig", menuName = "GameConfigs/Enemy/PatrolEnemyConfig", order = 52)]
    public class PatrolEnemyConfig : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _contactDamage;
        
        public float Speed => _speed;
        public float ContactDamage => _contactDamage;
    }
}