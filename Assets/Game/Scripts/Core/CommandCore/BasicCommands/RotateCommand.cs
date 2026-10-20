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
        private bool isRelativeRotation;
        private float rotationAngle;

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

            this.rotateDirection = (point.position - npc.transform.position);
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
            npc.MovementController.RotateTowards(rotateDirection);
        }

        protected override void OnComplete()
        {
            npc.MovementController.OnRotated -= Complete;
        } 
    }
}
