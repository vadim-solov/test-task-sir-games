using System.Collections.Generic;
using Game.Scripts.PlayerWeapons;
using UnityEngine;

namespace Game.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/GameConfig", fileName = "GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField]
        private float _waitingTimeForLevelActivation = 3f;
        [SerializeField]
        private Camera _cameraPrefab;
        [SerializeField]
        private Player.Player _playerPrefab;
        [SerializeField]
        private List<PlayerWeapon> _playerWeaponsPrefabs;
        [SerializeField]
        private List<Level> _allLevels;

        public Player.Player PlayerPrefab => _playerPrefab;
        public List<PlayerWeapon> PlayerWeaponsPrefabs => _playerWeaponsPrefabs;
        public List<Level> AllLevels => _allLevels;
        public Camera CameraPrefab => _cameraPrefab;
        public float WaitingTimeForLevelActivation => _waitingTimeForLevelActivation;
    }
}
