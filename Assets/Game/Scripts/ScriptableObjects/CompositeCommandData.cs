using Assets.Game.Scripts.Core.CommandCore;
using Assets.Game.Scripts.Core.CommandCore.BasicCommands;
using Assets.Game.Scripts.Gameplay.NPC;
using Assets.Game.Scripts.Models;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Game.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "NPC/Commands/CompositeCommandData", fileName = "CompositeCommandData")]
    public class CompositeCommandData : CommandData
    {
        [SerializeField] private List<CommandData> commandsData;
        public override ICommand GetCommand(NPC npc)
        {
            var commands = commandsData.Select(c => c.GetCommand(npc));
            return new ComplexCommand(commands);
        }
    }
}
