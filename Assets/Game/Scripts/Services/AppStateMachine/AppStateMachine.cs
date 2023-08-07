﻿using System;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.App.States;
using Game.Scripts.Services.CoinsSpawners;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.Factory;
using Game.Scripts.Services.GameDataProvider;
using Game.Scripts.Services.PlayerInstance;
using Zenject;

namespace Game.Scripts.Services.AppStateMachine
{
    public class AppStateMachine : IAppStateMachine
    {
        private readonly List<IState> _states;

        public IState CurrentState { get; private set; }

        [Inject]
        public AppStateMachine(IGameObjectFactory gameObjectFactory, IGameConfigDataProvider gameConfig,
            IPlayerGameObject playerGameObject, IAllEnemiesCollection allEnemiesCollection, ICoinSpawner coinSpawner)
        {
            _states = new List<IState>
            {
                new AppLoadingState(this),
                new LevelLoaderState(this, gameObjectFactory, playerGameObject),
                new CountdownState(this, gameConfig, allEnemiesCollection, playerGameObject),
                new GameplayState(playerGameObject, allEnemiesCollection, coinSpawner),
            };
        }

        public void Init(IState startState)
        {
            CurrentState = startState;
            CurrentState.Enter();
        }

        public void ChangeStateIfNewStateDifferent(IState newState)
        {
            if (newState.GetType() == CurrentState.GetType())
            {
                return;
            }

            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }

        public void TryChangeState<T>() where T : class, IState
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
