using UnityEngine;

namespace Game.Scripts.Services.PlayerInstance
{
    public interface IPlayerGameObject
    {
        public GameObject Instance { get; }
        public void SetPlayerInstance(GameObject player);
    }
}
