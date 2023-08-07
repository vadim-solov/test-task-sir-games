using Game.Scripts.Services.AppStateMachine;
using UnityEngine;

namespace Game.Scripts.App.States
{
    public class AppLoadingState : IState
    {
        private readonly IAppStateMachine _appStateMachine;

        public AppLoadingState(IAppStateMachine appStateMachine)
        {
            _appStateMachine = appStateMachine;
        }

        public void Enter()
        {
            Debug.Log("loading files...");
            _appStateMachine.ChangeState<LevelLoaderState>();
        }

        public void Run()
        {
        }

        public void Exit()
        {
            Debug.Log("loading files done!");
        }
    }
}
