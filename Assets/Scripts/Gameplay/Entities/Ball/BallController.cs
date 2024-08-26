using Gameplay.Entities.Common.Movement;
using System;
using System.Collections.Generic;
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

        #region Variables
        private List<IDisposable> _disposableObjects = new List<IDisposable>();
        private MovementController _movementController = null;
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

        #region Private Methods
        private void Init()
        {
            _movementController = new MovementController(_ballView, _ballModel);

            _disposableObjects.Add(_movementController);
        }

        private void Deinit()
        {
            if (_disposableObjects is null || _disposableObjects.Count.Equals(0))
            {
                return;
            }

            foreach (IDisposable disposableObject in _disposableObjects)
            {
                disposableObject.Dispose();
            }

            _disposableObjects.Clear();
        }
        #endregion
    }
}