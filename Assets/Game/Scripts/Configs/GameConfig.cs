using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/GameConfig", fileName = "GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField]
        private Player.Player _playerPrefab;
        [SerializeField]
        private List<Enemy.Enemy> _enemiesPrefabs;
        [SerializeField]
        private List<Level> _allLevelsPrefabs;

        public Player.Player PlayerPrefab => _playerPrefab;
        public List<Enemy.Enemy> EnemiesPrefabs => _enemiesPrefabs;
        public List<Level> AllLevelsPrefabs => _allLevelsPrefabs;
    }
}
