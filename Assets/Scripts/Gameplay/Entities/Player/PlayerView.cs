﻿using System;
using Gameplay.Entities.Common.Movement;
using Gameplay.InputSettings;
using UnityEngine;

namespace Gameplay.Entities.Player
{
    internal class PlayerView : MonoBehaviour, IMovementView
    {
        #region Editor Variables
        [Header("Player View")]
        [Header("Input settings")]
        [SerializeField] private PlayerInputSettings _inputSettings = null;
        #endregion

        #region Events
        public event Action<Vector2> OnMovementInputUpdated;
        #endregion

        #region Unity Methods
        private void Update()
        {
            UpdateInput();
        }
        #endregion

        #region Private Methods
        private void UpdateInput()
        {
            Vector2 rawInput = Vector2.zero;
            if (UnityEngine.Input.GetKey(_inputSettings.upKey))
            {
                rawInput.y += 1;
            }

            if (UnityEngine.Input.GetKey(_inputSettings.downKey))
            {
                rawInput.y += -1;
            }

            OnMovementInputUpdated?.Invoke(rawInput);
        }
        #endregion
    }
}