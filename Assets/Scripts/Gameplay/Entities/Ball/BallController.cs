using Gameplay.Entities.Player;
using Gameplay.Envirorment;
using System;
using UnityEngine;

namespace Gameplay.Entities.Ball
{
    public class BallController : MonoBehaviour
    {
        #region Editor Variables
        [Header("Ball Controller")]
        [Header("References")]
        [SerializeField] private BallView _ballView = null;
        [SerializeField] private BallModel _ballModel = null;
        #endregion

        #region Events
        public event Action<GoalZone> OnBallCollidesWithGoalZone = delegate { };
        #endregion

        #region Unity Methods
        private void Awake()
        {
            Init();
        }

        private void OnDestroy()
        {
            Deinit();
        }
        #endregion

        #region Public Methods
        public void StartBallMovement() => _ballModel.SetMovementDirection(UnityEngine.Random.insideUnitCircle.normalized);

        public void SetBallPosition(Vector3 newPosition, bool sleepRigidbody = true)
        {
            if (sleepRigidbody)
            {
                _ballModel.SleepRigidbody();
            }
            _ballModel.SetBallPosition(newPosition);
        }
        #endregion

        #region Callbacks
        private void BallView_OnBallColides(Collider2D collider) => HandleBallCollision(collider);
        #endregion

        #region Private Methods
        private void Init()
        {
            _ballView.OnBallCollides += BallView_OnBallColides;
        }

        private void Deinit()
        {
            _ballView.OnBallCollides -= BallView_OnBallColides;
        }

        private void HandleBallCollision(Collider2D collider)
        {
            if (collider.attachedRigidbody.TryGetComponent(out PlayerController playerController))
            {
                _ballModel.InvertMovementAxis("X");
            }

            switch (collider.tag)
            {
                case "VerticalWall":
                    GoalZone collidedGoalZone = collider.attachedRigidbody.GetComponent<GoalZone>();
                    OnBallCollidesWithGoalZone?.Invoke(collidedGoalZone);                   
                    break;
                case "HorizontalWall":
                    _ballModel.InvertMovementAxis("Y");
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}