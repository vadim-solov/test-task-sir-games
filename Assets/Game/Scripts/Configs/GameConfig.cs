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
        private List<Level> _allLevels;

        public Player.Player PlayerPrefab => _playerPrefab;
        public List<Level> AllLevels => _allLevels;
    }
}
