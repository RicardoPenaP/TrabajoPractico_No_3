using UnityEngine;

namespace Gameplay.InputSettings
{
    [CreateAssetMenu(fileName = "NewPlayerInputSettings", menuName = "Gameplay/Input/Player Input Settings")]
    public class PlayerInputSettings : ScriptableObject
    {
        #region Editor Variables
        [Header("Player Input Settings")]
        [SerializeField] private KeyCode _upKey = KeyCode.None;
        public KeyCode upKey => _upKey;

        [SerializeField] private KeyCode _downKey = KeyCode.None;
        public KeyCode downKey => _downKey;
        #endregion
    }
}

