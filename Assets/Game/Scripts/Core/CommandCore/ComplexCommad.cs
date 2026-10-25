using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Game.Scripts.Core.CommandCore
{
    public class ComplexCommand : ICommand
    {
        public bool IsCompleted { get; set; }

        private CommandQueueProcessor commandQueueProcessor;

        public ComplexCommand(IEnumerable<ICommand> commands) => new CommandQueueProcessor(commands);

        public virtual void Start()
        {
            IsCompleted = false;
        }

        public void Update()
        {
            if (IsCompleted) return;

            commandQueueProcessor.Update();

            if (commandQueueProcessor.IsCompleted)
                IsCompleted = true;
        }
    }
}
