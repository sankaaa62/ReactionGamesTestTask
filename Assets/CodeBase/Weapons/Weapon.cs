using UnityEngine;

namespace CodeBase.Actors.Fighting
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _spawnBulletPoint;

        public void Shoot(float damage, float speed)
        {
            var bullet = Instantiate(_bulletPrefab, _spawnBulletPoint.position, _spawnBulletPoint.rotation);
            bullet.Speed = speed;
            bullet.Damage = damage;
        }
    }
}