using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{
    public class CoinSpawner
    {
        private readonly GameObjectFactory _gameObjectFactory;
        private List<Coin> _allCoins = new List<Coin>();

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
        }
    }
}
