using Assets.Game.Scripts.Core.CommandCore.BasicCommands;
using Assets.Game.Scripts.Gameplay.NPC;
using Assets.Game.Scripts.Models;
using UnityEngine;

[CreateAssetMenu(menuName = "NPC/Commands/RotateToPointCommandData", fileName = "RotateToPointCommandData")]
public class RotateToPointCommandData : CommandData
{
    public PointType point;
    public override ICommand GetCommand(NPC npc) => new RotateCommand(npc, npc.PointStorage.GetPoint(point));
}
