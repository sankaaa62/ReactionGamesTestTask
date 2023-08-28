using UnityEngine;

namespace CodeBase.Actors.Targeting
{
    public abstract class FriendOrFoeSystem : MonoBehaviour
    {
        public abstract bool IsFoe(Transform other);

        public abstract bool IsFriend(Transform other);
    }
}