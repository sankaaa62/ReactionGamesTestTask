using System;

namespace CodeBase.Actors.Fighting
{
    public class EnemyDeath : Death
    {
        public override event Action DiedEvent;

        public override void Die()
        {
            DiedEvent?.Invoke();
            Destroy(gameObject);
        }
    }
}