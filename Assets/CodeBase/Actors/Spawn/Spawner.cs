using System;
using UnityEngine;

namespace CodeBase.Actors.Spawn
{
    public abstract class Spawner : MonoBehaviour
    {
        public abstract event Action<GameObject> SpawnedEvent;
        public bool IsSpawnOnStart;
        protected virtual Color GizmoColor => new Color(0f, 0f, 1f, 0.75f);
        
        public abstract void Spawn();

        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = GizmoColor;
            Gizmos.DrawSphere(transform.position, 1);
        }
        
    }
}