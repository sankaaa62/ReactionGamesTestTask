using UnityEngine;

namespace CodeBase.Actors.Following
{
    public abstract class Follow : MonoBehaviour
    {
        public Transform Target { get; set; }
    }
}