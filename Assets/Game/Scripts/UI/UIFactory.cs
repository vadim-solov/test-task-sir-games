using UnityEngine;

namespace Game.Scripts.UI
{
    public class UIFactory
    {
        private readonly Canvas _canvas = Resources.Load<Canvas>("Canvas");

        public void CreateGameplayCanvas()
        {
            Object.Instantiate(_canvas);
        }
    }
}
