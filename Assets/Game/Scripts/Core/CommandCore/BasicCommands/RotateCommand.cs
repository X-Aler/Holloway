using Assets.Game.Scripts.Core.FSM;
using Assets.Game.Scripts.Gameplay.NPC;
using Assets.Game.Scripts.Systems.Controllers;
using UnityEngine;

namespace Assets.Game.Scripts.Core.CommandCore.BasicCommands
{
    public class RotateCommand : BaseCommand
    {
        private NPC npc;
        private Vector3 rotateDirection;
        private readonly bool isRelativeRotation;
        private readonly float rotationAngle;
        private readonly Transform targetPoint;

        public RotateCommand(NPC npc, Vector3 rotateDirection)
        {
            this.npc = npc;
            this.rotateDirection = rotateDirection;
        }

        public RotateCommand(NPC npc, float rotationAngle)
        {
            this.npc = npc;
            this.rotationAngle = rotationAngle;

            isRelativeRotation = true;
        }
        public RotateCommand(NPC npc, Transform point)
        {
            this.npc = npc;

            this.targetPoint = point;
        }

        public override void Start()
        {
            if (isRelativeRotation)
            {
                rotateDirection = Quaternion.Euler(0f, rotationAngle, 0f) * npc.transform.forward;
            }

            npc.MovementController.OnRotated += Complete;
        }

        public override void Update()
        {
            if (targetPoint != null)
            {
                rotateDirection = targetPoint.position - npc.transform.position;
            }

            npc.MovementController.RotateTowards(rotateDirection);
        }

        protected override void OnComplete()
        {
            npc.MovementController.OnRotated -= Complete;
        } 
    }
}
