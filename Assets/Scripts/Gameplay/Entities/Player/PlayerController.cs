using Gameplay.Entities.Common.Movement;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Entities.Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Editor Variables
        [Header("Player Controller")]
        [Header("References")]
        [SerializeField] private PlayerView _playerView = null;
        [SerializeField] private PlayerModel _playerModel = null;

        private List<IDisposable> _disposableObjects = null;
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
            MovementController movementController = new MovementController(_playerView, _playerModel);
            _disposableObjects.Add(movementController);
        }

        private void Deinit()
        {
            if (_disposableObjects is null || _disposableObjects.Count.Equals(0))
            {
                return;
            }

            foreach (IDisposable obj in _disposableObjects)
            {
                obj.Dispose();
            }

            _disposableObjects.Clear();
        }
        #endregion
    }
}

