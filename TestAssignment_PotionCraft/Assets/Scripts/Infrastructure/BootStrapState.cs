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
           RegisterServices();
        }

        private void RegisterServices()
        {
            Game.InputService = SetupInputService();
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