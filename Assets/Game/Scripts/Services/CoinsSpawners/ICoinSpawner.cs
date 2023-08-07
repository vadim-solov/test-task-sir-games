using UnityEngine;

namespace Game.Scripts.Services.CoinsSpawners
{
    public interface ICoinSpawner
    {
        public void CreateAndAddToCollection(Vector3 position);
        public void SummonAllCoinsToPosition(Vector3 position);
    }
}
