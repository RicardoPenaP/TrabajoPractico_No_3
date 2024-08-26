using Gameplay.Entities.Common.Movement;
using System;
using UnityEngine;

namespace Gameplay.Entities.Ball
{
    public class BallView : MonoBehaviour, IMovementView
    {
        public event Action<Vector2> OnMovementInputUpdated;
    }
}