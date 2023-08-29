using UnityEngine;

namespace CodeBase.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "GameConfigs/PlayerConfig", order = 51)]
    public class HeroConfig : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _maxHp;

        public float Speed => _speed;
        public float MaxHp => _maxHp;
    }
}