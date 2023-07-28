﻿using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Game.Scripts
{
    public class CoinSpawner
    {
        private readonly GameObjectFactory _gameObjectFactory;
        private readonly List<Coin> _allCoins = new List<Coin>();

        private const float TimeSummonMovement = 1f;

        public CoinSpawner(GameObjectFactory gameObjectFactory)
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
