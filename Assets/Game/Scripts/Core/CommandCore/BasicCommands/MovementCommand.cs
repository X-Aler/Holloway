using Assets.Game.Scripts.Gameplay.NPC;
using UnityEngine;

namespace Assets.Game.Scripts.Core.CommandCore.BasicCommands
{
    public class MovementCommand : BaseCommand
    {
        private Vector3 movePosition;

        private NPC npc;
        
        public MovementCommand(NPC npc, Vector3 movePosition)
        {
            this.npc = npc;
            this.movePosition = movePosition;
        }

        public override void Start()
        {
            npc.MovementController.OnArrived += Complete;

            Debug.Log("StartMoving");
        }

        public override void Update()
        {
            npc.MovementController.MoveTo(movePosition);
        }

        protected override void OnComplete()
        {
            Debug.Log("Reached");
            npc.MovementController.OnArrived -= Complete;
        } 
    }
}
