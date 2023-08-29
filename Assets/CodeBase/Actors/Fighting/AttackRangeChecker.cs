using CodeBase.Actors.Fighting;
using UnityEngine;

namespace CodeBase.Actors.Targeting
{
    public class AttackRangeChecker : MonoBehaviour
    {
        [SerializeField] private TargetSelector _targetSelector;
        [SerializeField] private Attack _attack;
        [Space] 
        [SerializeField] private float _attackRange;
        
        private void OnDisable()
        {
            SwitchAttackFalse();
        }

        private void Update()
        {
            RefreshAttackStatus();
        }

        private void RefreshAttackStatus()
        {
            if (CanAttack())
                SwitchAttackTrue();
            else
                SwitchAttackFalse();
        }

        private bool CanAttack()
        {
            return HasTarget() && IsTargetInAttackRange();
        }

        private bool HasTarget()
        {
            return _targetSelector.Target != null;
        }
        
        private bool IsTargetInAttackRange()
        {
            return (_targetSelector.Target.position - transform.position).sqrMagnitude < Mathf.Pow(_attackRange, 2);
        }

        private void SwitchAttackFalse()
        {
            _attack.enabled = false;
        }

        private void SwitchAttackTrue()
        {
            _attack.enabled = true;
        }
    }
}