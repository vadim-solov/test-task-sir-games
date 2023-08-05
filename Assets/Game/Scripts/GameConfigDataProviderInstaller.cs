using Game.Scripts.Configs;
using Game.Scripts.Services.GameDataProvider;
using UnityEngine;
using Zenject;

namespace Game.Scripts
{
    public class GameConfigDataProviderInstaller : MonoInstaller
    {
        [SerializeField]
        private GameConfig _gameConfig;

        public override void InstallBindings()
        {
            IGameConfigDataProvider gameConfigDataProvider = new GameConfigDataProvider(_gameConfig);
            Container.Bind<IGameConfigDataProvider>().FromInstance(gameConfigDataProvider).AsSingle();
        }
    }
}
