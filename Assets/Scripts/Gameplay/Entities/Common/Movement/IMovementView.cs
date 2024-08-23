using System;
using UnityEngine;

namespace Gameplay.Entities.Common.Movement
{
    public interface IMovementView
    {
        public event Action<Vector2> OnMovementInputUpdate;
    }
}