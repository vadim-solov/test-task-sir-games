using Game.Scripts.App.States;
using Game.Scripts.Services.AppStateMachine;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Bootstrappers
{
    public class GameSceneBootstrapper : MonoBehaviour
    {
        private IAppStateMachine _appStateMachine;

        [Inject]
        private void Construct(IAppStateMachine appStateMachine)
        {
            _appStateMachine = appStateMachine;
        }

        private void Awake()
        {
            _appStateMachine.ChangeState<AppLoadingState>();
        }

        private void Update()
        {
            _appStateMachine.CurrentState.Run();
        }
    }
}
