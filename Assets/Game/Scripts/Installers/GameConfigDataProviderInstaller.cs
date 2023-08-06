using Game.Scripts.Configs;
using Game.Scripts.Services.GameDataProvider;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField]
        private GameConfig _gameConfig;

        public override void InstallBindings()
        {
            BindGameConfigDataProvider();
        }

        private void BindGameConfigDataProvider()
        {
            IGameConfigDataProvider gameConfigDataProvider = new GameConfigDataProvider(_gameConfig);
            Container.Bind<IGameConfigDataProvider>().FromInstance(gameConfigDataProvider).AsSingle();
        }
    }
}
