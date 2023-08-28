using CodeBase.Actors.Following;
using UnityEngine;

namespace CodeBase.Actors.Targeting
{
    public class Agro : MonoBehaviour
    {
        [SerializeField] private TargetSelector _targetSelector;
        [SerializeField] private Follow _follow;

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
            if (_targetSelector.Target == null)
                SwitchAgroFalse();
            else
                SwitchAgroTrue();
        }

        private void SwitchAgroFalse()
        {
            _follow.Target = null;
            _follow.enabled = false;
        }

        private void SwitchAgroTrue()
        {
            _follow.Target = _targetSelector.Target;
            _follow.enabled = true;
        }
    }
}