using UnityEngine;

namespace CodeBase.Actors.Targeting
{
    public class EnemyFriendOrFoeSystem : FriendOrFoeSystem
    {
        public override bool IsFoe(Transform other)
        {
            return other.TryGetComponent<Hero>(out var hero);
        }

        public override bool IsFriend(Transform other)
        {
            return other.TryGetComponent<Enemy>(out var enemy);
        }
    }
}