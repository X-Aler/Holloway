using Assets.Game.Scripts.Gameplay.NPC;
using UnityEngine;
using Assets.Game.Scripts.Utils;

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
            npc.MovementController.MoveTo(movePosition);
        }

        public override void Update()
        {
            if (npc.MovementController.HasReachedDestination()) Complete();
        }

        protected override void OnComplete()
        {
            npc.MovementController.Stop();
        } 
    }
}
