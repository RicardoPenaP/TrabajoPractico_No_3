using System;
using UnityEngine;

namespace Gameplay.Entities.Common.Collisions
{
    public class CollisionHandler : MonoBehaviour
    {
        #region Events
        public event Action<Collider2D> OnCollisionDetected = delegate { };
        #endregion

        #region Unity Methods
        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionDetected?.Invoke(collision.collider);
        }
        #endregion
    }
}