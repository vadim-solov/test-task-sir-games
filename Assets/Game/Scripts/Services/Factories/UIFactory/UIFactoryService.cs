using Game.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Services.Factories.UIFactory
{
    public class UIFactoryService : IUIFactoryService
    {
        private readonly DiContainer _diContainer;
        private readonly GameplayUI _canvas = Resources.Load<GameplayUI>("Canvas");

        [Inject]
        public UIFactoryService(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public GameplayUI CreateGameplayCanvas()
        {
            return _diContainer.InstantiatePrefabForComponent<GameplayUI>(_canvas);
        }
    }
}
