﻿using System.Collections.Generic;
using DG.Tweening;
using Game.Scripts.Services.Factories.GameObjectFactory;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Services.CoinsSpawners
{
    public class CoinSpawner : ICoinSpawner
    {
        private readonly IGameObjectFactory _gameObjectFactory;
        private readonly List<Coin> _allCoins = new List<Coin>();

        private const float TimeSummonMovement = 1f;

        [Inject]
        public CoinSpawner(IGameObjectFactory gameObjectFactory)
        {
            _gameObjectFactory = gameObjectFactory;
        }

        public void CreateAndAddToCollection(Vector3 position)
        {
            Coin coin = _gameObjectFactory.CreateCoin(position);
            _allCoins.Add(coin);
        }

        public void SummonAllCoinsToPosition(Vector3 position)
        {
            foreach (Coin coin in _allCoins)
            {
                coin.transform.DOMove(position, TimeSummonMovement).OnComplete(() => Object.Destroy(coin.gameObject));
            }
        }
    }
}
