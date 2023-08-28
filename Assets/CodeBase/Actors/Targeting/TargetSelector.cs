using System;
using UnityEngine;

namespace CodeBase.Actors.Targeting
{
    public abstract class TargetSelector : MonoBehaviour
    {
        public virtual event Action TargetChangedEvent;
        public virtual Transform Target { get; protected set; }
    }
}