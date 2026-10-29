using Assets.Game.Scripts.Gameplay.NPC;
using UnityEngine;

public abstract class CommandData : ScriptableObject
{
    public MoodType CommandType;
    public abstract ICommand GetCommand(NPC npc);
}
