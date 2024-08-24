using System;
using Gameplay.Entities.Common.Movement;
using Gameplay.Input;
using UnityEngine;

namespace Gameplay.Entities.Player
{
    internal class PlayerView : MonoBehaviour, IMovementView
    {
        #region Editor Variables
        [Header("Player View")]
        [Header("Input settings")]
        [SerializeField] private InputSettings _inputSettings = null;
        #endregion

        #region Events
        public event Action<Vector2> OnMovementInputUpdate;
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

            OnMovementInputUpdate?.Invoke(rawInput);
        }
        #endregion
    }
}