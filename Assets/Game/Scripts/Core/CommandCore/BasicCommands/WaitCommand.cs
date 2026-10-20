using Assets.Game.Scripts.Models;

namespace Assets.Game.Scripts.Core.CommandCore.BasicCommands
{
    public class WaitCommand : BaseCommand
    {
        private float waitSeconds;
        private bool isControlWaiting;

        private GameTimeManager gameTimeManager;

        public WaitCommand(GameTime waitTime)
        {
            waitSeconds = waitTime.TotalSeconds;
            isControlWaiting = false;
        }

        public WaitCommand() { isControlWaiting = true; }

        public override void Start()
        {
            gameTimeManager = GameTimeManager.Instance;

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
