using System.Collections;
using TMPro;
using UnityEngine;

namespace Gameplay.Systems.Game
{
    public class GameView : MonoBehaviour
    {
        #region Editor Variables
        [Header("Game View")]

        [Header("References")]
        [SerializeField] private TextMeshProUGUI _startText = null;
        [SerializeField] private TextMeshProUGUI _winnerText = null;
        [SerializeField] private TextMeshProUGUI _player1ScoreText = null;
        [SerializeField] private TextMeshProUGUI _player2ScoreText = null;

        [Header("Settings")]
        [SerializeField] private float _startTextBlinkTime = 0.3f;
        #endregion

        #region Variables
        private bool _startTextIsBlinking = false;
        private IEnumerator _startTextBlinkingCoroutine = null;
        #endregion

        #region Unity Methods
        private void Awake()
        {
            Init();
        }
        #endregion

        #region Public Methods
        public void SetStartTextBlinkingState(bool state)
        {
            if (_startTextIsBlinking == state)
            {
                return;
            }

            _startTextIsBlinking = state;

            if (_startTextIsBlinking)
            {               
                StartCoroutine(_startTextBlinkingCoroutine);
            }
            else
            {
                StopCoroutine(_startTextBlinkingCoroutine);
                _startText.gameObject.SetActive(false);
            }
        }
        #endregion

        #region Private Methods
        private void Init()
        {
            _startTextBlinkingCoroutine = StartTextBlinkingRoutine();
        }

        #endregion

        #region Coroutines
        private IEnumerator StartTextBlinkingRoutine()
        {
            do
            {
                _startText.gameObject.SetActive(!_startText.gameObject.activeSelf); 
                yield return new WaitForSeconds(_startTextBlinkTime);
            } while (true);           
        }
        #endregion
    }
}