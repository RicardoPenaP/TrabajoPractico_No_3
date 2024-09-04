using Gameplay.Entities.Player;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Systems.Game
{
    public class GameModel : MonoBehaviour
    {
        #region Constants
        private const int AmountOfPlayers = 2;
        private const int DefaultAmountOfPoints = 1;
        #endregion

        #region Variables
        private GameStatus _gameStatus = GameStatus.None;
        public GameStatus gameStatus => _gameStatus;

        private Dictionary<PlayerId, int> _scoreDictionary = new Dictionary<PlayerId, int>();

        private int _maxScore = 3;
        public int maxScore => _maxScore;        
        #endregion

        #region Events
        public event Action<GameStatus> OnGameStatusChange = delegate { };
        public event Action<PlayerId, int> OnScoreChange = delegate { };
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

        public void AddScore(PlayerId playerId, int points = DefaultAmountOfPoints)
        {
            if (!_scoreDictionary.ContainsKey(playerId))
            {
                Debug.LogError($"The score dictionary doesn\'t contains {playerId}");
                return;
            }

            _scoreDictionary[playerId] += Mathf.Abs(points);
            Debug.Log($"{playerId} => { _scoreDictionary[playerId]}");
            OnScoreChange?.Invoke(playerId, _scoreDictionary[playerId]);
        }

        public PlayerId GetPlayerWithHighestScore()
        {
            PlayerId player = PlayerId.None;
            int score = 0;   

            foreach (KeyValuePair<PlayerId, int> item in _scoreDictionary)
            {
                if (item.Value < score)
                {
                    continue;
                }

                score = item.Value;
                player = item.Key;
            }

            return player;
        }
        #endregion

        #region Private Methods
        private void Init()
        {
            for (int i = 0; i < AmountOfPlayers; i++)
            {
                _scoreDictionary.Add((PlayerId)i + 1, 0);
            }
            SetGameStatus(GameStatus.Stopped);
        }
        #endregion
    }
}