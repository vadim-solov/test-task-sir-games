using Game.Scripts.App;
using Game.Scripts.Configs;
using Game.Scripts.Services.Input;
using UnityEngine;

namespace Game.Scripts.CompositeRoot
{
    public class MainCompositeRoot : MonoBehaviour
    {
        [SerializeField]
        private GameConfig _gameConfig;

        private IInputService _inputService;

        private void Awake()
        {
            _inputService = new DesktopInput();
            GameObjectFactory gameObjectFactory = new GameObjectFactory(_gameConfig, _inputService);
            AppStateChanger appStateChanger = new AppStateChanger(gameObjectFactory);
            appStateChanger.StartApp();
        }

        private void Update()
        {
            _inputService.Update();
        }
    }
}
