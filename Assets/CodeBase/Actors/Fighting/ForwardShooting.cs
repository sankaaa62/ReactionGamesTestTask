using UnityEngine;

namespace CodeBase.Actors.Fighting
{
    public class ForwardShooting : Shooting
    {
        [SerializeField] private Weapon _weapon;
        [Space]
        [SerializeField] private float _attackCooldown;
        [SerializeField] private float _damage;
        [SerializeField] private float _bulletSpeed;

        private float _shootTimer;

        public override float AttackCooldown
        {
            get => _attackCooldown;
            set => _attackCooldown = value;
        }
        public override float Damage
        {
            get => _damage;
            set => _damage = value;
        }
        public override float BulletSpeed
        {
            get => _bulletSpeed;
            set => _bulletSpeed = value;
        }

        private void Update()
        {
            UpdateTimer();

            if (CanShoot()) 
                Shoot();
        }

        private void Shoot()
        {
            TimerIsUp();
            _weapon.Shoot(Damage, BulletSpeed);
        }

        private bool CanShoot()
        {
            return _shootTimer >= _attackCooldown;
        }

        private void TimerIsUp()
        {
            _shootTimer -= _attackCooldown;
        }

        private void UpdateTimer()
        {
            _shootTimer += Time.deltaTime;
        }
    }
}