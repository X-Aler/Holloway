using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Game.Scripts.Helpers
{
    public enum Scenes
    {
        MainMenu,
        MainGame,
        LoadScene
    }

    public static class ScenesStorage
    {
        public static string GetScene(Scenes scene) => scene switch
        {
            Scenes.MainMenu => "MainMenu",
            Scenes.MainGame => "MainGame",
            Scenes.LoadScene => "LoadScene",
             _ => throw new NotImplementedException()
        };
    }
}
