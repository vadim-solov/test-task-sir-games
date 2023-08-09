using System;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Game.States;
using Game.Scripts.Services.CoinsSpawners;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.Factories.GameObjectFactory;
using Game.Scripts.Services.Factories.UIFactory;
using Game.Scripts.Services.GameDataProvider;
using Game.Scripts.Services.PlayerInstance;
using Zenject;

namespace Game.Scripts.Services.GameStateMachine
{
    public class GameStateMachine : IStateMachine
    {
        private readonly List<IState> _states;

        public IState CurrentState { get; private set; }

        [Inject]
        public GameStateMachine(IGameObjectFactory gameObjectFactory, IGameConfigDataProvider gameConfig,
            IPlayerGameObject playerGameObject, IAllEnemiesCollection allEnemiesCollection, ICoinSpawner coinSpawner,
            IUIFactoryService uiFactoryService)
        {
            _states = new List<IState>
            {
                new GameLoadingState(this),
                new LevelLoaderState(this, gameObjectFactory, playerGameObject, uiFactoryService),
                new CountdownState(this, gameConfig, allEnemiesCollection, playerGameObject),
                new GameplayState(playerGameObject, allEnemiesCollection, coinSpawner),
            };
        }

        public void ChangeState<T>() where T : class, IState
        {
            CurrentState?.Exit();

            IState newState = null;

            foreach (IState state in _states.Where(state => typeof(T) == state.GetType()))
            {
                newState = state;
            }

            if (newState == null)
            {
                throw new Exception("state not found");
            }

            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}
