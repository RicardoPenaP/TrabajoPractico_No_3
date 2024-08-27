using Gameplay.Entities.Common.Collisions;
using System;
using UnityEngine;

namespace Gameplay.Entities.Ball
{
    public class BallView : MonoBehaviour
    {
        #region Editor Variables
        [Header("Ball View")]
        [Header("References")]
        [SerializeField] private CollisionHandler _collisionHandler = null;
        #endregion

        #region Events        
        public event Action<Collider2D> OnBallCollides = delegate { };
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

        #region Callbacks
        private void CollisionHandler_OnCollisionDetected(Collider2D collider) => OnBallCollides?.Invoke(collider);
       
        #endregion

        #region Private Methods
        private void Init()
        {
            _collisionHandler.OnCollisionDetected += CollisionHandler_OnCollisionDetected;
        }

        private void Deinit()
        {
            _collisionHandler.OnCollisionDetected -= CollisionHandler_OnCollisionDetected;
        }
        #endregion
    }
}