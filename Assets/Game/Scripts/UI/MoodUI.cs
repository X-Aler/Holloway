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
        private Image smileImage;
        public MoodUI(Slider slider, Image image)
        {
            moodSlider = slider;
            smileImage = image;
        }

        public void UpdateUI(float value, Sprite smile)
        {
            moodSlider.value = value;

            smileImage.sprite = smile;
        }
    }
}
