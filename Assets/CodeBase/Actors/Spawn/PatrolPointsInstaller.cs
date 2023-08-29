using CodeBase.Actors.Idling;
using UnityEngine;

namespace CodeBase.Actors.Spawn
{
    public class PatrolPointsInstaller : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;
        [SerializeField] private Transform[] _points;
        
        private void Awake()
        {
            _spawner.SpawnedEvent += OnSpawned;
        }

        private void OnDestroy()
        {
            _spawner.SpawnedEvent -= OnSpawned;
        }

        private void OnSpawned(GameObject actor)
        {
            if (actor.TryGetComponent<Patrol>(out var patrol))
                patrol.SetPoints(_points);
        }
    }
}