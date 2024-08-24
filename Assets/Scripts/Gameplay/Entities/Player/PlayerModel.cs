using Gameplay.Entities.Common.Movement;
using UnityEngine;

namespace Gameplay.Entities.Player
{
    internal class PlayerModel : MonoBehaviour, IMovementModel
    {
        #region Editor Variables
        [Header("Player Model")]
        [Header("References")]
        [SerializeField] private Rigidbody2D _rigidbody = null;

        [Header("Movement Settings")]
        [SerializeField] private MovementSettings _movementSettings = null;
        #endregion

        #region Variables
        private float _movementSpeedMultiplier = 1f;
        #endregion

        #region Public Methods
        public void SetMovementDirection(Vector2 normalizedMovementDirection)
        {
            _rigidbody.velocity = normalizedMovementDirection * _movementSettings.baseMovementSpeed * _movementSpeedMultiplier;
        }

        public void StopMovement()
        {
            SetMovementDirection(Vector2.zero);
        }
        #endregion

    }
}