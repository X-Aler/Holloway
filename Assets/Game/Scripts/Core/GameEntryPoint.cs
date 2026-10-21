using System;
using System.Diagnostics;
using VContainer.Unity;

namespace Assets.Game.Scripts.Core
{
    public class GameEntryPoint : IInitializable, IStartable, IDisposable
    {
        private readonly PlayerControls playerControls;
        private readonly GameTimeManager gameTimeManager;

        public GameEntryPoint(PlayerControls playerControls, GameTimeManager gameTimeManager)
        {
            this.playerControls = playerControls;
            this.gameTimeManager = gameTimeManager;
        }

        public void Initialize()
        {
            CursorController.Lock();
            playerControls.Enable();
            gameTimeManager.Initialzie();
        }

        public void Start()
        {
            gameTimeManager.StartShift();
        }

        public void Dispose()
        {
            playerControls.Disable();
        }
    }
}
