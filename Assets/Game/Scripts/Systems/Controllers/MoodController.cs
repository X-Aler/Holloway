using Assets.Game.Scripts.Gameplay.NPC;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Game.Scripts.Systems.Controllers
{
    public class MoodController
    {
        public event Action<float> OnMoodChanged;
        public float CurrentMoodValue => currentMoodValue;
        public CommandType CurrentMood => currentMood;

        private NPC npc;

        private float currentMoodValue;

        private CommandType currentMood;

        private MoodData moodData;

        public MoodController(NPC npc, MoodData moodData)
        {
            this.npc = npc;
            this.moodData = moodData;
        }

        public void ChangeMood(float value)
        {
            currentMoodValue += Math.Clamp(value, 0, 1);

            OnMoodChanged?.Invoke(currentMoodValue);

            currentMood = GetMood();
        }

        private CommandType GetMood()
        {
            CommandType mood;

            if (currentMoodValue >= moodData.GoodMoodValue)
                mood = CommandType.Good;
            else if (currentMoodValue >= moodData.NeutralMoodValue)
                mood = CommandType.Neutral;
            else
                mood = CommandType.Bad;

            return mood;
        }
    }
}
