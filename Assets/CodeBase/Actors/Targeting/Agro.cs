using CodeBase.Actors.Following;
using UnityEngine;

namespace CodeBase.Actors.Targeting
{
    public class Agro : MonoBehaviour
    {
        [SerializeField] private TargetSelector _targetSelector;
        [SerializeField] private Follower _follower;

        private void Awake()
        {
            _targetSelector.TargetChangedEvent += OnTargetChanged;
            
            SwitchAgroFalse();
        }
        
        private void OnDestroy()
        {
            _targetSelector.TargetChangedEvent -= OnTargetChanged;
        }

        private void OnEnable()
        {
            RefreshAgroStatus();
        }

        private void OnDisable()
        {
            SwitchAgroFalse();
        }

        private void OnTargetChanged()
        {
            if (enabled == false)
                return;
            
            RefreshAgroStatus();
        }

        private void RefreshAgroStatus()
        {
            if (HasTarget())
                SwitchAgroTrue();
            else
                SwitchAgroFalse();
        }

        private bool HasTarget()
        {
            return _targetSelector.Target != null;
        }

        private void SwitchAgroFalse()
        {
            _follower.Target = null;
            _follower.enabled = false;
        }

        private void SwitchAgroTrue()
        {
            _follower.Target = _targetSelector.Target;
            _follower.enabled = true;
        }
    }
}