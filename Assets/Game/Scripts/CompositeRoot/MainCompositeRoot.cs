using Game.Scripts.App;
using Game.Scripts.Configs;
using Game.Scripts.Player;
using Game.Scripts.Services.Input;
using UnityEngine;

namespace Game.Scripts.CompositeRoot
{
    public class MainCompositeRoot : MonoBehaviour
    {
        [SerializeField]
        private PlayerStatesChanger _playerStatesChanger;
        [SerializeField]
        private GameConfig _gameConfig;

        private IInputService _inputService;

        private void Awake()
        {
            GameObjectFactory gameObjectFactory = new GameObjectFactory(_gameConfig);
            AppStateChanger appStateChanger = new AppStateChanger(gameObjectFactory);
            _inputService = new DesktopInput();
            //_playerStatesChanger.Init(_inputService);

            appStateChanger.StartApp();
        }

        private void Update()
        {
            _inputService.Update();
        }
    }
}
