using UnityEngine;

namespace CodeBase.Actors.Moving
{
    public interface IToPointMover
    {
        public void MoveToPoint(Vector3 targetPoint);

        public void StopMove();
    }
}