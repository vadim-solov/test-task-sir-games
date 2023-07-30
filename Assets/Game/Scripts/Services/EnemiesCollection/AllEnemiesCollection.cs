﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Scripts.Services.EnemiesCollection
{
    public class AllEnemiesCollection : IAllEnemiesCollection
    {
        private readonly List<GameObject> _allEnemies = new List<GameObject>();

        public List<GameObject> AllEnemies => new List<GameObject>(_allEnemies);

        public event Action<GameObject> EnemyRemoved;
        public event Action CollectionIsEmpty;

        public void AddEnemyToCollection(GameObject enemy)
        {
            _allEnemies.Add(enemy);
        }

        public void RemoveFromCollection(GameObject enemy)
        {
            _allEnemies.Remove(enemy);
            EnemyRemoved?.Invoke(enemy);
            CheckEnemiesCount();
        }

        private void CheckEnemiesCount()
        {
            if (_allEnemies.Count <= 0)
            {
                CollectionIsEmpty?.Invoke();
            }
        }

        public GameObject FindClosestEnemy(Vector3 position)
        {
            return _allEnemies.Count == 0
                ? null
                : _allEnemies.OrderBy(enemy => Vector3.Distance(position, enemy.transform.position)).FirstOrDefault();
        }
    }
}
