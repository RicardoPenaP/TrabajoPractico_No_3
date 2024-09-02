using UnityEngine;

namespace Gameplay.Input
{
    [CreateAssetMenu(fileName = "NewInputSettings", menuName = "Gameplay/Input/Input Settings")]
    public class PlayerInputSettings : ScriptableObject
    {
        #region Editor Variables
        [Header("Input Settings")]
        [SerializeField] private KeyCode _upKey = KeyCode.None;
        public KeyCode upKey => _upKey;

        [SerializeField] private KeyCode _downKey = KeyCode.None;
        public KeyCode downKey => _downKey;
        #endregion

    }
}

