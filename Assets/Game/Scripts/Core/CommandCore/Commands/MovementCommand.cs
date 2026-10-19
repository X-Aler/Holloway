using Assets.Game.Scripts.Gameplay.NPC;
using UnityEngine;

namespace Assets.Game.Scripts.Core.CommandCore.Commands
{
    public class MovementCommand : ICommand
    {
        public bool IsCompleted { get; set; }

        private Vector3 movePosition;

        private NPC npc;
        
        public MovementCommand(NPC npc, Vector3 movePosition)
        {
            this.npc = npc;
            this.movePosition = movePosition;
        }

        public void Start()
        {
            npc.MovementController.OnReached += OnCompleted;
        }

        public void Update()
        {
            npc.MovementController.MoveTo(movePosition);
        }

        private void OnCompleted()
        {
            IsCompleted = true;

            npc.MovementController.OnReached -= OnCompleted;
        } 
    }
}
