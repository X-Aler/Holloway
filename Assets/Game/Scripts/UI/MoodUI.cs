using Assets.Game.Scripts.Systems.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.UI
{
    public class MoodUI
    {
        private Slider moodSlider;
        public MoodUI(Slider slider)
        {
            moodSlider = slider;
        }

        public void UpdateUI(float value)
        {
            moodSlider.value = value;
        }
    }
}
