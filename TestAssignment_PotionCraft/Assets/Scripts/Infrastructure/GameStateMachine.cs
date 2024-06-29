using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, IState>();
        }

        public void EntryPoint<TState>() where TState : IState
        {
            _activeState?.Exit();
            IState _state = _states[typeof(IState)];
            _activeState = _state;
            _state.Enter();
        }
    }
}