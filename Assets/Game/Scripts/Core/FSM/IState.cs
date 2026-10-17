using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Game.Scripts.Core.FSM
{
    public interface IState
    {
        void Enter();
        void Update();
        void Exit();
    }
}
