using Gameplay.Entities.Player;
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
        
        #region Unity Methods
        private void Awake()
        {
            //Temp Code
            _ballModel.SetMovementDirection(Random.insideUnitCircle.normalized);
            Init();
        }

        private void OnDestroy()
        {
            Deinit();
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
                    //_ballModel.StopMovement();
                    _ballModel.InvertMovementAxis("X");
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