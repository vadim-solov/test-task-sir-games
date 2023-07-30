using UnityEngine;

namespace Game.Scripts.Services.PlayerInstance
{
    public class PlayerGameObject : IPlayerGameObject
    {
        public GameObject Instance { get; private set; }

        public void SetPlayerInstance(GameObject player)
        {
            Instance = player;
        }
    }
}
