using Game.Scripts.Projectiles;
using UnityEngine;

namespace Game.Scripts.Services.Factories.GameObjectFactory
{
    public interface IGameObjectFactory
    {
        public Camera CreateCamera(Transform cameraTargetTransform);
        public void CreateLevel();
        public GameObject CreatePlayerAndSetPosition();
        public void CreateEnemiesAndSetPositions();
        public void CreateAndSetPlayerWeapon(GameObject player);
        public Projectile CreateProjectile(Projectile projectile, Vector3 attackPointPosition);
        public Coin CreateCoin(Vector3 position);
    }
}
