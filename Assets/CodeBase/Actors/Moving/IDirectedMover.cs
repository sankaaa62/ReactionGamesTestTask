using UnityEngine;

namespace CodeBase.Actors.Moving
{
    public interface IDirectedMover : IMover
    {
        public void Move(Vector3 direction);
    }
}