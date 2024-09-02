using Gameplay.InputSettings;
using Gameplay.Entities.Ball;
using Gameplay.Entities.Player;
using Gameplay.Envirorment;
using System;
using UnityEngine;

namespace Gameplay.Systems.Game
{
    public class GameController : MonoBehaviour
    {
        #region Editor Variables
        [Header("Game Controller")]
        [Header("MVC References")]
        [SerializeField] private GameView _gameView = null;
        [SerializeField] private GameModel _gameModel = null;

        [Header("Input References")]
        [SerializeField] private GameInputSettings _inputSettings = null;

        [Header("Ball References")]
        [SerializeField] private BallController _ball = null;
        [SerializeField] private Transform _ballStartPos = null;
        #endregion

        #region Unity Methods
        private void Awake()
        {
            Init();
        }

        private void Update()
        {
            UpdateGameInput();
        }

        private void OnDestroy()
        {
            Detinit();
        }
        #endregion

        #region Callbacks
        private void CurrentBall_OnBallCollidesWithGoalZone(GoalZone goalZone) => HandleGoal(goalZone.zoneId);

        private void GameModel_OnGameStatusChange(GameStatus newStatus) => HandleGameStatusChange(newStatus);

        #endregion

        #region Private Methods
        private void Init()
        {
            _gameModel.OnGameStatusChange += GameModel_OnGameStatusChange;

            _ball.OnBallCollidesWithGoalZone += CurrentBall_OnBallCollidesWithGoalZone;
        }

        private void UpdateGameInput()
        {
            if (Input.GetKeyDown(_inputSettings.startKey) && _gameModel.gameStatus == GameStatus.Stopped)
            {
                _ball.StartBallMovement();
                _gameModel.SetGameStatus(GameStatus.Started);
            }
        }

        private void Detinit()
        {
            _gameModel.OnGameStatusChange += GameModel_OnGameStatusChange;

            _ball.OnBallCollidesWithGoalZone -= CurrentBall_OnBallCollidesWithGoalZone;
        }

        private void HandleGoal(PlayerId zoneId)
        {
            _ball.SetBallPosition(_ballStartPos.position);
            _gameModel.SetGameStatus(GameStatus.Stopped);
            // Logic for giving points and winning condition check 
        }

        private void HandleGameStatusChange(GameStatus newStatus)
        {
            
        }


        #endregion
    }
}
