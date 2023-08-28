using System;
using UnityEngine;

namespace CodeBase.Utils
{
    [RequireComponent(typeof(Collider))]
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider> TriggerEnterEvent; 
        public event Action<Collider> TriggerExitEvent; 

        private void OnTriggerEnter(Collider other)
        {
            TriggerEnterEvent?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            TriggerExitEvent?.Invoke(other);
        }
    }
}