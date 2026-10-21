using Assets.Game.Scripts.Core.CommandCore.BasicCommands;
using Assets.Game.Scripts.Gameplay.NPC;
using Assets.Game.Scripts.Models;
using UnityEngine;

[CreateAssetMenu(menuName = "NPC/Commands/WaitCommandData", fileName = "WaitCommandData")]
public class WaitCommandData : CommandData
{
    public GameTime waitTime;
    public override ICommand GetCommand(NPC npc) => new WaitCommand(npc.GameTimeManager, waitTime);
}