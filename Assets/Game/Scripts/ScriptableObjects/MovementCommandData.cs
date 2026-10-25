using Assets.Game.Scripts.Core.CommandCore.BasicCommands;
using Assets.Game.Scripts.Gameplay.NPC;
using Assets.Game.Scripts.Models;
using UnityEngine;

[CreateAssetMenu(menuName = "NPC/Commands/MovementCommandData", fileName = "MovementCommandData")]
public class MovementCommandData : CommandData
{
    public PointType point;
    public override ICommand GetCommand(NPC npc) => new MovementCommand(npc, npc.PointStorage.GetPoint(point).PointPosition);
}
