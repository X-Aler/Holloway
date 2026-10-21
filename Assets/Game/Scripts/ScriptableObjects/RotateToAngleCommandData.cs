using Assets.Game.Scripts.Core.CommandCore.BasicCommands;
using Assets.Game.Scripts.Gameplay.NPC;
using UnityEngine;

[CreateAssetMenu(menuName = "NPC/Commands/RotateToAngleCommandData", fileName = "RotateToAngleCommandData")]
public class RotateToAngleCommandData : CommandData
{
    public float angle;
    public override ICommand GetCommand(NPC npc) => new RotateCommand(npc, angle);
}
