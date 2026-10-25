using System.Linq;
using UnityEngine;

namespace Assets.Game.Scripts.Models
{
    public enum PointType
    {
        NpcSpawn,
        Enter,
        Pickup,
        FittingRoom,
    }

    public class PointStorage : MonoBehaviour
    {
        [SerializeField] private Point npcSpawnPoint;
        [SerializeField] private Point enterPoint;
        [SerializeField] private Point[] pickupPoint;
        [SerializeField] private Point[] fittingRoomPoints;

        public Point GetPoint(PointType type)
        {
            return type switch
            {
                PointType.NpcSpawn => npcSpawnPoint,
                PointType.Enter => enterPoint,
                PointType.Pickup => GetPoint(pickupPoint),
                PointType.FittingRoom => GetPoint(fittingRoomPoints),
                _ => null
            };
        }

        private Point GetPoint(Point[] points)
        {
            if (points == null || points.Length == 0)
                return null;

            return points.FirstOrDefault(p => p.IsOccupied == false);
        }
    }
}
