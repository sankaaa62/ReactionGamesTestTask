using UnityEngine;

namespace CodeBase.Actors.Fighting
{
    public abstract class Attack : MonoBehaviour
    {
        public abstract float Damage { get; set; }
        public abstract float AttackCooldown { get; set; }
    }
}