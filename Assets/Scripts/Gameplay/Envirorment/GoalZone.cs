using Gameplay.Entities.Player;
using UnityEngine;

namespace Gameplay.Envirorment
{
    public class GoalZone : MonoBehaviour
    {
        #region Editor Variables
        [Header("Goal Zone")]
        [SerializeField] private PlayerId _zoneId = PlayerId.None;
        public PlayerId zoneId => _zoneId;
        #endregion
    }
}