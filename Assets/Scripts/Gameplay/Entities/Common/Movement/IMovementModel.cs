using UnityEngine;

namespace Gameplay.Entities.Common.Movement
{
    public interface IMovementModel
    {
        public void SetMovementDirection(Vector2 normalizedMovementDirection);
        public void StopMovement();
    }
}