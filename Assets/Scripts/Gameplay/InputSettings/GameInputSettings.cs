using UnityEngine;

namespace Gameplay.InputSettings
{
    [CreateAssetMenu(fileName = "NewGameInputSettings", menuName = "Gameplay/Input/Game Input Settings")]
    public class GameInputSettings : ScriptableObject
    {
        #region Editor Variables
        [Header("Game Input Settings")]
        [SerializeField] private KeyCode _startKey = KeyCode.None;
        public KeyCode startKey => _startKey;

        [SerializeField] private KeyCode _pauseKey = KeyCode.None;
        public KeyCode pauseKey => _pauseKey;
        #endregion
    }
}