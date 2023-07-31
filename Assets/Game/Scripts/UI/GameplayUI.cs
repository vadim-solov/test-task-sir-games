using Game.Scripts.Services.GameDataProvider;
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

        private float _countdownTime;

        public void Init(IGameConfigDataProvider gameConfig)
        {
            _countdownTime = gameConfig.WaitingTimeForLevelActivation;
        }

        private void Update()
        {
            ReduceCountdownTime();
            SetInputAxis();
            CheckAndSetCountdownTimer();
        }

        private void ReduceCountdownTime()
        {
            _countdownTime -= Time.deltaTime;
        }

        private void SetInputAxis()
        {
            InputService.Axis = new Vector3(_fixedJoystick.Horizontal, 0f, _fixedJoystick.Vertical);
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
