using Game.Scripts.Services.GameDataProvider;
using TMPro;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class GameplayUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _countdownTimer;

        private float _countdownTime;

        public void Init(IGameConfigDataProvider gameConfig)
        {
            _countdownTime = gameConfig.WaitingTimeForLevelActivation;
        }

        private void Update()
        {
            ReduceCountdownTime();
            CheckAndSetCountdownTimer();
        }

        private void ReduceCountdownTime()
        {
            _countdownTime -= Time.deltaTime;
        }

        private void CheckAndSetCountdownTimer()
        {
            if (_countdownTime <= 0f)
            {
                RefreshCountdownTimerText();
                return;
            }

            _countdownTimer.text = _countdownTime.ToString("0");
        }

        private void RefreshCountdownTimerText()
        {
            _countdownTimer.text = "";
        }
    }
}
