using UnityEngine;

namespace CodeBase.Actors.Following
{
    public abstract class Follower : MonoBehaviour
    {
        public Transform Target { get; set; }
    }
}