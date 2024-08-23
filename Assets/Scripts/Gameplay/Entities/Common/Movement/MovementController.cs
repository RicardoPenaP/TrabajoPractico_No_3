namespace Gameplay.Entities.Common.Movement
{
    public class MovementController
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
        }

        #endregion


    }
}