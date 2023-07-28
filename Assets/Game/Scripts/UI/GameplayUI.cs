using Game.Scripts.App;
using Game.Scripts.Configs;
using Game.Scripts.Services.Input;
using TMPro;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class GameplayUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _countdownTimer;
        [SerializeField]
        private FixedJoystick _fixedJoystick;

        private AppStateChanger _appStateChanger;
        private float _waitingTimeForLevelActivation;

        public void Init(AppStateChanger appStateChanger, GameConfig gameConfig)
        {
            _appStateChanger = appStateChanger;
            _waitingTimeForLevelActivation = gameConfig.WaitingTimeForLevelActivation;
        }

        private void Update()
        {
            SetInputAxis();
            SetCountdownTimer();
        }

        private void SetInputAxis()
        {
            InputService.Axis = new Vector3(_fixedJoystick.Horizontal, 0f, _fixedJoystick.Vertical);
        }

        private void SetCountdownTimer()
        {
            float countdownTimerValue = _waitingTimeForLevelActivation - _appStateChanger.CountdownState.Timer;

            if (countdownTimerValue <= 0f)
            {
                RefreshCountdownTimerText();
                return;
            }

            _countdownTimer.text = countdownTimerValue.ToString("0");
        }

        private void RefreshCountdownTimerText()
        {
            _countdownTimer.text = "";
        }
    }
}
