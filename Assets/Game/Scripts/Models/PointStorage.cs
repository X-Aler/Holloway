using UnityEngine;

namespace Assets.Game.Scripts.Models
{
    public enum PointType
    {
        NpcSpawn,
        Enter,
        Pickup,
        FittingRoom,
        Player
    }

    public class PointStorage : MonoBehaviour
    {
        [SerializeField] private Transform npcSpawnPoint;
        [SerializeField] private Transform enterPoint;
        [SerializeField] private Transform pickupPoint;
        [SerializeField] private Transform playerPoint;
        [SerializeField] private Transform[] fittingRoomPoints;

        public Transform GetPoint(PointType type)
        {
            return type switch
            {
                PointType.NpcSpawn => npcSpawnPoint,
                PointType.Enter => enterPoint,
                PointType.Pickup => pickupPoint,
                PointType.Player => playerPoint,
                PointType.FittingRoom => GetRandomFittingRoom(),
                _ => null
            };
        }

        private Transform GetRandomFittingRoom()
        {
            if (fittingRoomPoints == null || fittingRoomPoints.Length == 0)
                return null;

            return fittingRoomPoints[Random.Range(0, fittingRoomPoints.Length)];
        }
    }
}
