using UnityEngine;

namespace CodeBase.Actors.Fighting
{
    public class Bullet : MonoBehaviour
    {
        public float LifeTime = 5;
        public float Speed = 10;
        public float Damage = 1;

        private float _lifeTimer;
        
        private void Update()
        {
            _lifeTimer += Time.deltaTime;
            if (_lifeTimer > LifeTime) 
                Destroy(gameObject);
            
            ForwardMove();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.TryGetComponent<IDamageTaker>(out var damageTaker)) 
                damageTaker.TakeDamage(Damage);
            
            Destroy(gameObject);
        }

        private void ForwardMove()
        {
            transform.Translate(Vector3.forward * (Speed * Time.deltaTime));
        }
    }
}