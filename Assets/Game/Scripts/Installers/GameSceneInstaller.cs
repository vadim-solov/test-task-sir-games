using Game.Scripts.Configs;
using Game.Scripts.Services.CoinsSpawners;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.EnemiesGetter;
using Game.Scripts.Services.Factory;
using Game.Scripts.Services.GameDataProvider;
using Game.Scripts.Services.Input;
using Game.Scripts.Services.PlayerInstance;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField]
        private GameConfig _gameConfig;

        public override void InstallBindings()
        {
            BindGameConfigDataProvider();
            BingEnemyConfigGetter();
            BindAllEnemiesCollection();
            BindPlayerGameObject();
            BindInput();
            BindGameObjectFactory();
            BindCoinSpawner();
        }

        private void BindGameConfigDataProvider()
        {
            IGameConfigDataProvider gameConfigDataProvider = new GameConfigDataProvider(_gameConfig);
            Container.Bind<IGameConfigDataProvider>().FromInstance(gameConfigDataProvider).AsSingle().NonLazy();
        }

        private void BingEnemyConfigGetter()
        {
            Container.Bind<IEnemyConfigGetter>().To<EnemyConfigGetter>().FromNew().AsSingle().NonLazy();
        }

        private void BindAllEnemiesCollection()
        {
            Container.Bind<IAllEnemiesCollection>().To<AllEnemiesCollection>().FromNew().AsSingle().NonLazy();
        }

        private void BindPlayerGameObject()
        {
            Container.Bind<IPlayerGameObject>().To<PlayerGameObject>().FromNew().AsSingle().NonLazy();
        }

        private void BindInput()
        {
            Container.Bind<IInputService>().To<DesktopInput>().FromNew().AsSingle().NonLazy();
        }

        private void BindGameObjectFactory()
        {
            Container.Bind<IGameObjectFactory>().To<GameObjectFactory>().FromNew().AsSingle().NonLazy();
        }

        private void BindCoinSpawner()
        {
            Container.Bind<ICoinSpawner>().To<CoinSpawner>().FromNew().AsSingle().NonLazy();
        }

        // private IInputService GetInputService()
        // {
        //     return Application.isEditor ? (IInputService)new DesktopInput() : new MobileInput();
        // }
    }
}
