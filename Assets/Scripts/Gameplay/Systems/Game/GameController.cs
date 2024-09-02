using Gameplay.Entities.Ball;
using Gameplay.Entities.Player;
using Gameplay.Envirorment;
using UnityEngine;

namespace Gameplay.Systems.Game
{
    public class GameController : MonoBehaviour
    {
        #region Editor Variables
        [Header("Game Controller")]
        [Header("References")]
        [SerializeField] private BallController _ball = null;
        [SerializeField] private Transform _ballStartPos = null;
        #endregion

        #region Variables
        private BallController _currentBall = null;
        #endregion

        #region Unity Methods
        private void Awake()
        {
            Init();
        }

        private void OnDestroy()
        {
            Detinit();
        }
        #endregion

        #region Callbacks
        private void CurrentBall_OnBallCollidesWithGoalZone(GoalZone goalZone) => HandleGoal(goalZone.zoneId);
        

        #endregion

        #region Private Methods
        private void Init()
        {
            _currentBall.OnBallCollidesWithGoalZone += CurrentBall_OnBallCollidesWithGoalZone;
        }

        private void Detinit()
        {
            _currentBall.OnBallCollidesWithGoalZone -= CurrentBall_OnBallCollidesWithGoalZone;
        }

        private void HandleGoal(PlayerId zoneId)
        {
            _currentBall.SetBallPosition(_ballStartPos.position);

            // Logic for giving points and winning condition check 
        }
        #endregion
    }
}
