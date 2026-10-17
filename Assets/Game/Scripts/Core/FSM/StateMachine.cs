using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Game.Scripts.Core.FSM
{
    public class StateMachine
    {
        public IState CurrentState { get; private set; }

        public void Initialize(IState baseState)
        {
            CurrentState = baseState;

            baseState.Enter();
        }

        public void ChangeState(IState newState)
        {
            CurrentState.Exit();

            CurrentState = newState;

            CurrentState.Enter();
        }
    }
}
