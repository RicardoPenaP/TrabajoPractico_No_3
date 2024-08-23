using UnityEngine;

namespace Gameplay.Entities.Common.Movement
{
    [CreateAssetMenu(fileName = "NewMovementSettings", menuName = "Gameplay/Entities/Common/Movement/Movement Settings")]
    public class MovementSettings : ScriptableObject
    {
        #region Editor Variables
        [Header("Movement Settings")]
        [SerializeField] private float _baseMovementSpeed = 10f;
        public float baseMovementSpeed => _baseMovementSpeed;

        [Range(0f, 100f)]
        [SerializeField] private float _speedAugmentPercentage = 25f;
        public float speedAugmentPercentage => _speedAugmentPercentage;
        #endregion
    }
}