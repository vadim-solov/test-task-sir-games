using Game.Scripts.App.States;
using Game.Scripts.Services.AppStateMachine;
using Game.Scripts.Services.GameDataProvider;
using Game.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Game.Scripts.CompositeRoot
{
    //bootstrap
    public class MainCompositeRoot : MonoBehaviour
    {
        private IGameConfigDataProvider _gameConfigDataProvider;
        private IAppStateMachine _appStateMachine;

        [Inject]
        private void Construct(IGameConfigDataProvider gameConfigDataProvider, IAppStateMachine appStateMachine)
        {
            _gameConfigDataProvider = gameConfigDataProvider;
            _appStateMachine = appStateMachine;
        }

        private void Awake()
        {
            Init();
            _appStateMachine.TryChangeState<AppLoadingState>();
        }

        private void Init()
        {
            UIFactory uiFactory = new UIFactory();
            GameplayUI gameplayUI = uiFactory.CreateGameplayCanvas();
            gameplayUI.Init(_gameConfigDataProvider);
        }

        private void Update()
        {
            _appStateMachine.CurrentState.Run();
        }
    }
}
