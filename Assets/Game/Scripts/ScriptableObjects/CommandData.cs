using Assets.Game.Scripts.Gameplay.NPC;
using UnityEngine;

public abstract class CommandData : ScriptableObject
{
    public CommandType CommandType;
    public abstract ICommand GetCommand(NPC npc);
}
