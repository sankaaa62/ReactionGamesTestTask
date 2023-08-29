using System;
using UnityEngine;

namespace CodeBase.Actors.Fighting
{
    public abstract class Death : MonoBehaviour
    {
        public abstract event Action DiedEvent; 
        public abstract void Die();
    }
}