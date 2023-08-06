using Game.Scripts.Configs;
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
            IGameConfigDataProvider gameConfigDataProvider = new GameConfigDataProvider(_gameConfig);
            Container.Bind<IGameConfigDataProvider>().FromInstance(gameConfigDataProvider).AsSingle().NonLazy();

            EnemyConfigGetter enemyConfigGetter = new EnemyConfigGetter(gameConfigDataProvider);

            Container.Bind<IEnemyConfigGetter>().To<EnemyConfigGetter>().FromInstance(enemyConfigGetter).AsSingle()
                .NonLazy();

            AllEnemiesCollection allEnemiesCollection = new AllEnemiesCollection();
            Container.Bind<IAllEnemiesCollection>().To<AllEnemiesCollection>().FromInstance(allEnemiesCollection)
                .AsSingle().NonLazy();

            Container.Bind<IPlayerGameObject>().To<PlayerGameObject>().FromNew().AsSingle().NonLazy();

            Container.Bind<IInputService>().To<DesktopInput>().FromNew().AsSingle().NonLazy();

            Container.Bind<IGameObjectFactory>().To<GameObjectFactory>().FromNew().AsSingle().WithArguments(
                gameConfigDataProvider, allEnemiesCollection, enemyConfigGetter, Container);
        }

        // private IInputService GetInputService()
        // {
        //     return Application.isEditor ? (IInputService)new DesktopInput() : new MobileInput();
        // }
    }
}
