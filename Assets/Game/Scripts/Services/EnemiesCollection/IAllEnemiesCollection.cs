using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Services.EnemiesCollection
{
    public interface IAllEnemiesCollection
    {
        public List<GameObject> AllEnemies { get; }
        public bool IsCollectionEmpty { get; }

        public event Action<GameObject> EnemyRemoved;
        public event Action CollectionIsEmpty;

        public void AddEnemyToCollection(GameObject enemy);
        public void RemoveFromCollection(GameObject enemy);
        public GameObject FindClosestEnemy(Vector3 position);
    }
}
