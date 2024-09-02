using System;
using UnityEngine;

namespace Gameplay.Systems.Game
{
    public class GameModel : MonoBehaviour
    {
        #region Variables
        private GameStatus _gameStatus = GameStatus.None;
        public GameStatus gameStatus => _gameStatus;
        #endregion

        #region Events
        public event Action<GameStatus> OnGameStatusChange = delegate { };
        #endregion

        #region Unity Methods
        private void Start()
        {
            Init();
        }
        #endregion

        #region PublicMethods
        public void SetGameStatus(GameStatus newStatus)
        {
            if (_gameStatus == newStatus)
            {
                return;
            }
            _gameStatus = newStatus;
            OnGameStatusChange?.Invoke(gameStatus);
        }
        #endregion

        #region Private Methods
        private void Init()
        {
            SetGameStatus(GameStatus.Stopped);
        }
        #endregion
    }
}