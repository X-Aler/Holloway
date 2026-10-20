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
        private PointStorage pointStorage;

        private Player player;

        public AliveState(NPC npc, PointStorage pointStorage, StateMachine stateMachine, Player player)
        {
            this.npc = npc;
            this.stateMachine = stateMachine;
            this.pointStorage = pointStorage;
            this.player = player;
        }

        public void Enter()
        {
            npc.CommandsRunner.AddCommand(new MovementCommand(npc, pointStorage.enterPoint.position));
            npc.CommandsRunner.AddCommand(new WaitCommand(new GameTime(0, 10)));
            npc.CommandsRunner.AddCommand(new RotateCommand(npc, 45));
            npc.CommandsRunner.AddCommand(new RotateCommand(npc, -90));
            npc.CommandsRunner.AddCommand(new MovementCommand(npc, pointStorage.pickupPoint.position));
            npc.CommandsRunner.AddCommand(new RotateCommand(npc, -pointStorage.pickupPoint.forward));
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
