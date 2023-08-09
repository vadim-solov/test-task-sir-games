using Game.Scripts.Game.States;
using Game.Scripts.Services.GameStateMachine;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Bootstrappers
{
    public class GameSceneBootstrapper : MonoBehaviour
    {
        private IStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            _gameStateMachine.ChangeState<GameLoadingState>();
        }

        private void Update()
        {
            _gameStateMachine.CurrentState.Run();
        }
    }
}
