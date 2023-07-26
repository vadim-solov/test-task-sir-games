﻿using Game.Scripts.Game;
using Game.Scripts.Game.States;
using Game.Scripts.Player;
using Game.Scripts.Services.Input;
using UnityEngine;

namespace Game.Scripts.CompositeRoot
{
    public class MainCompositeRoot : MonoBehaviour
    {
        [SerializeField]
        private PlayerStatesChanger _playerStatesChanger;

        private IInputService _inputService;

        private void Awake()
        {
            GameObjectFactory gameObjectFactory = new GameObjectFactory();
            AppStateChanger appStateChanger = new AppStateChanger(gameObjectFactory);
            _inputService = new DesktopInput();
            _playerStatesChanger.Init(_inputService);

            appStateChanger.StartApp();
        }

        private void Update()
        {
            _inputService.Update();
        }
    }
}
