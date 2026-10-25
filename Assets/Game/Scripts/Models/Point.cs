using Assets.Game.Scripts.Gameplay.NPC;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Game.Scripts.Models
{
    [Serializable]
    public class Point
    {
        [SerializeField] private Transform pointTransform;
        private NPC npc;

        public Transform PointTransform => pointTransform;
        public Vector3 PointPosition => pointTransform.position;
        public Quaternion PointRotation => pointTransform.rotation;
        public bool IsOccupied => npc != null;
        public NPC NPC => npc;

        public bool TryOccupy(NPC npc)
        {
            if (IsOccupied) return false;

            this.npc = npc;

            return true;
        }
        public void Clear()
        {
            if (!IsOccupied) return;

            npc = null;
        }
    }
}
