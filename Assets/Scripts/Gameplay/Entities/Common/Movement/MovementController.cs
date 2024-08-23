using System;
using UnityEngine;

namespace Gameplay.Entities.Common.Movement
{
    public class MovementController : IDisposable
    {
        #region Variables
        private readonly IMovementView _movementView;
        private readonly IMovementModel _movementModel;
        #endregion

        #region Constructors
        public MovementController(IMovementView movementView, IMovementModel movementModel)
        {
            _movementView = movementView;
            _movementModel = movementModel;
            Init();
        }

        #endregion

        #region Public Methods
        public void Dispose()
        {
            Deinit();
        }
        #endregion        

        #region Private Methods
        private void Init()
        {
            _movementView.OnMovementInputUpdate += MovementView_OnMovementInputUpdate;
        }

        private void Deinit()
        {
            _movementView.OnMovementInputUpdate -= MovementView_OnMovementInputUpdate;
        }
        #endregion

        #region Callbacks
        private void MovementView_OnMovementInputUpdate(Vector2 rawMovementInput)
        {
            if (rawMovementInput.Equals(Vector2.zero))
            {
                _movementModel.SetMovementDirection(rawMovementInput.normalized);
            }
            else
            {
                _movementModel.StopMovement();
            }
        }
        #endregion
    }
}