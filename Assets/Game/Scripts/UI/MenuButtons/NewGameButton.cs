using Assets.Game.Scripts.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Game.Scripts.UI.MenuButtons
{
    public class NewGameButton : ButtonBase
    {
        protected override void OnClick() => SceneLoader.Instance.LoadScene(Scenes.MainGame);
    }
}
