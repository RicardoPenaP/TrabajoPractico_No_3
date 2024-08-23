using UnityEngine;

namespace Gameplay.Entities.Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Editor Variables
        [Header("Player Controller")]
        [Header("References")]
        [SerializeField] private PlayerView playerView = null;
        [SerializeField] private PlayerModel playerModel = null;
        #endregion
    }
}

