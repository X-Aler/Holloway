using AutoGroupGenerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Game.Scripts.Core.CommandCore
{
    public class CommandsRunner
    {
        private CommandQueueProcessor commandQueueProcessor;
        public bool IsRunning => commandQueueProcessor.IsRunning;
        public bool IsCompleted => commandQueueProcessor.IsCompleted;

        public CommandsRunner(IEnumerable<ICommand> commands) => commandQueueProcessor = new CommandQueueProcessor(commands);
        public CommandsRunner() => commandQueueProcessor = new CommandQueueProcessor();

        public void AddCommand(ICommand command) => commandQueueProcessor.AddCommand(command);

        public void Update() => commandQueueProcessor.Update();
    }
}
