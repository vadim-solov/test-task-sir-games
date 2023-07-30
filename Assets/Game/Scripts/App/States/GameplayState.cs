﻿using Game.Scripts.Enemies.States;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.App.States
{
    public class GameplayState : IState
    {
        private readonly IPlayerGameObject _playerGameObject;
        private readonly IAllEnemiesCollection _allEnemiesCollection;
        private readonly CoinSpawner _coinSpawner;

        public GameplayState(IPlayerGameObject playerGameObject, IAllEnemiesCollection allEnemiesCollection,
            CoinSpawner coinSpawner)
        {
            _playerGameObject = playerGameObject;
            _allEnemiesCollection = allEnemiesCollection;
            _coinSpawner = coinSpawner;
        }

        public void Enter()
        {
            ActivatePlayer();
            ActivateEnemies();
            _allEnemiesCollection.EnemyRemoved += OnEnemyRemoved;
            _allEnemiesCollection.CollectionIsEmpty += OnEnemiesCollectionIsEmpty;
        }

        public void Run()
        {
        }

        public void Exit()
        {
            _allEnemiesCollection.EnemyRemoved -= OnEnemyRemoved;
            _allEnemiesCollection.CollectionIsEmpty -= OnEnemiesCollectionIsEmpty;
        }

        private void ActivatePlayer()
        {
            _playerGameObject.Instance.SetAttackState();
        }

        private void ActivateEnemies()
        {
            foreach (GameObject enemy in _allEnemiesCollection.AllEnemies)
            {
                MonoBehaviourStateMachine stateMachine = enemy.GetComponent<MonoBehaviourStateMachine>();
                EnemyMovementState movementState = enemy.GetComponent<EnemyMovementState>();
                stateMachine.ChangeStateIfNewStateDifferent(movementState);
            }
        }

        private void OnEnemyRemoved(GameObject enemy)
        {
            _coinSpawner.CreateAndAddToCollection(enemy.transform.position);
        }

        private void OnEnemiesCollectionIsEmpty()
        {
            _coinSpawner.SummonAllCoinsToPosition(_playerGameObject.Instance.transform.position);
        }
    }
}
