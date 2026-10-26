using Assets.Game.Scripts.Gameplay.NPC;
using Assets.Game.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Game.Scripts.Systems.Controllers
{
    public class MoodPresenter : IDisposable
    {
        public readonly MoodController MoodController;
        public readonly MoodUI MoodUI;

        public MoodPresenter(MoodController controller, MoodUI ui)
        {
            MoodController = controller;

            MoodUI = ui;

            MoodController.OnMoodChanged += MoodUI.UpdateUI;
        }

        public void Dispose()
        {
            MoodController.OnMoodChanged -= MoodUI.UpdateUI;
        }
    }
}
