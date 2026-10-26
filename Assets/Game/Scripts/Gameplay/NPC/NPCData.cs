using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Game.Scripts.Gameplay.NPC
{
    [CreateAssetMenu(fileName = "NPCData", menuName = "NPC/NPCData")]
    public class NPCData : ScriptableObject
    {
        public GameObject PhonePrefab;

        [SerializeField] private MoodData moodData;
        [SerializeField] private List<CommandData> commmandsPool;

        public IReadOnlyList<CommandData> CommandsPool => commmandsPool;
        public MoodData MoodData => moodData;
    }
}
