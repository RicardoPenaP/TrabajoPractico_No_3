using Gameplay.Entities.Common.Movement;
using UnityEngine;

namespace Gameplay.Entities.Ball
{
    public class BallModel : MonoBehaviour
    {
        #region Editor Variables
        [Header("Ball Model")]
        [Header("References")]
        [SerializeField] private Transform _targetTransform = null;
        [SerializeField] private Rigidbody2D _rigidbody = null;

        [Header("Movement Settings")]
        [SerializeField] private MovementSettings _movementSettings = null;
        #endregion

        #region Variables
        private float _movementSpeedMultiplier = 1f;
        #endregion

        #region Properties

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

        public void InvertMovementAxis(string axis)
        {
            string toUpperAxis = axis.ToUpper();
            Vector2 newMovementDirection = _rigidbody.velocity;
            _rigidbody.Sleep();
            switch (axis)
            {
                case "X":
                    newMovementDirection.x = newMovementDirection.x * -1;
                    break;
                case "Y":
                    newMovementDirection.y = newMovementDirection.y * -1;
                    break;
                default:
                    Debug.Log($"Not suported axis name: {axis}");
                    break;
            }
            _rigidbody.velocity = newMovementDirection;
        }

        public void SetBallPosition(Vector3 newPosition) => _targetTransform.position = newPosition;

        public void SleepRigidbody() => _rigidbody.Sleep();
        #endregion


    }
}