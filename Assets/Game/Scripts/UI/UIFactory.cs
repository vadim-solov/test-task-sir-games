using UnityEngine;

namespace Game.Scripts.UI
{
    public class UIFactory
    {
        private readonly GameplayUI _canvas = Resources.Load<GameplayUI>("Canvas");

        public GameplayUI CreateGameplayCanvas()
        {
            return Object.Instantiate(_canvas);
        }
    }
}
