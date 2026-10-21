using Assets.Game.Scripts.Core.CommandCore.BasicCommands;
using Assets.Game.Scripts.Gameplay.NPC;
using Assets.Game.Scripts.Models;
using UnityEngine;

namespace Assets.Game.Scripts.Core.FSM.States
{
    public class AliveState : IState
    {
        private NPC npc;
        private StateMachine stateMachine;

        public AliveState(NPC npc, StateMachine stateMachine)
        {
            this.npc = npc;
            this.stateMachine = stateMachine;
        }

        public void Enter()
        {

        }

        public void Update()
        {
            npc.CommandsRunner.Update();
        }

        public void Exit()
        {

        }
    }
}
