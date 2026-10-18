using Assets.Game.Scripts.Core.CommandCore.Commands;
using Assets.Game.Scripts.Gameplay.NPC;
using Assets.Game.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Unity.Profiling;

namespace Assets.Game.Scripts.Core.FSM.States
{
    public class AliveState : IState
    {
        private NPC npc;
        private StateMachine stateMachine;
        private PointStorage pointStorage;

        public AliveState(NPC npc, PointStorage pointStorage, StateMachine statateMachine)
        {
            this.npc = npc;
            this.stateMachine = statateMachine;
            this.pointStorage = pointStorage;
        }

        public void Enter()
        {
            npc.CommandsRunner.AddCommand(new MovementCommand(npc, pointStorage.enterPoint.position));
            npc.CommandsRunner.AddCommand(new MovementCommand(npc, pointStorage.pickupPoint.position));
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
