using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Game.Scripts.UI.MenuButtons
{
    public class QuitButton : ButtonBase
    {
        protected override void OnClick() => Application.Quit(); 
    }
}
