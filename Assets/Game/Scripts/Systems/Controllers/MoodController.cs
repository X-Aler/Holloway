using Assets.Game.Scripts.Gameplay.NPC;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Game.Scripts.Systems.Controllers
{
    public class MoodController
    {
        public event Action<float, Sprite> OnMoodChanged;
        public float CurrentMoodValue => currentMoodValue;
        public MoodType CurrentMood => currentMood;

        private NPC npc;

        private float currentMoodValue;

        private MoodType currentMood;

        private MoodData moodData;

        public MoodController(NPC npc, MoodData moodData)
        {
            this.npc = npc;
            this.moodData = moodData;
        }

        public void ChangeMood(float value)
        {
            currentMoodValue += value;

            currentMoodValue = Math.Clamp(currentMoodValue, 0f, 1f);

            currentMood = GetMood();

            OnMoodChanged?.Invoke(currentMoodValue, moodData.GetSmile(currentMood));
        }

        private MoodType GetMood()
        {
            MoodType mood;

            if (currentMoodValue >= moodData.GoodMoodValue)
                mood = MoodType.Good;
            else if (currentMoodValue >= moodData.NeutralMoodValue)
                mood = MoodType.Neutral;
            else
                mood = MoodType.Bad;

            return mood;
        }
    }
}
