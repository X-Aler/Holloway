using Assets.Game.Scripts.Models;

namespace Assets.Game.Scripts.Core.CommandCore.BasicCommands
{
    public class WaitCommand : BaseCommand
    {
        private float waitSeconds;
        private bool isControlWaiting;
        private GameTimeManager gameTimeManager;

        public WaitCommand(GameTimeManager manager, GameTime waitTime)
        {
            gameTimeManager = manager;
            waitSeconds = waitTime.TotalSeconds;
            isControlWaiting = false;
        }

        public WaitCommand(GameTimeManager manager) 
        {
            gameTimeManager = manager;
            isControlWaiting = true; 
        }

        public override void Start()
        {
            if (!isControlWaiting && waitSeconds <= 0) Complete();
        }

        public override void Update()
        {
            if (IsCompleted || isControlWaiting) return;

            waitSeconds -= gameTimeManager.DeltaTimeSeconds;

            if (waitSeconds <= 0) Complete();
        }

        public void StopWait() => Complete();
    }
}
