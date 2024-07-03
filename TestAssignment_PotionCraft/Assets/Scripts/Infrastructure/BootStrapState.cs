using System;
using GameServices.Input;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Infrastructure
{
    public class BootStrapState : IState
    {
        private GameStateMachine _stateMachine;

        public BootStrapState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            Debug.Log("Entering BootStrapState");
            RegisterServices();
        }

        private void RegisterServices()
        {
            Game.InputService = SetupInputService();
            Debug.Log("InputService registered: " + (Game.InputService != null));
        }

        public void Exit()
        {
        }

        private static IInputService SetupInputService()
        {
            return new DefaultInput();
        }
    }
}