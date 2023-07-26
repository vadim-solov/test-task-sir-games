using Game.Scripts.App;
using Game.Scripts.Configs;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.Input;
using UnityEngine;

namespace Game.Scripts.CompositeRoot
{
    public class MainCompositeRoot : MonoBehaviour
    {
        [SerializeField]
        private GameConfig _gameConfig;

        private AppStateChanger _appStateChanger;
        private IInputService _inputService;

        private void Awake()
        {
            _inputService = new DesktopInput();
            IAllEnemiesCollection allEnemiesCollection = new AllEnemiesCollection();
            GameObjectFactory gameObjectFactory =
                new GameObjectFactory(_gameConfig, _inputService, allEnemiesCollection);
            _appStateChanger = new AppStateChanger(gameObjectFactory, _gameConfig);
            _appStateChanger.StartApp();
        }

        private void OnDisable()
        {
            _appStateChanger.Disable();
        }

        private void Update()
        {
            _appStateChanger.Update();
            _inputService.Update();
        }
    }
}
