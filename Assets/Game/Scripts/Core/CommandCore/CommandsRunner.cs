using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Game.Scripts.Core.CommandCore
{
    public class CommandsRunner
    {
        private readonly List<ICommand> commands = new List<ICommand>();
        private ICommand currentCommand;
        public bool IsRunning => currentCommand != null;
        public bool IsCompleted => !IsRunning;

        public void AddCommand(ICommand command) => commands.Add(command);

        public void Update()
        {
            if (currentCommand == null)
            {
                if (commands.Count <= 0)
                    return;

                currentCommand = GetCommand();

                currentCommand.Start();
            }

            currentCommand.Update();

            if (currentCommand.IsCompleted)
            {
                currentCommand = null;
            }
        }

        private ICommand GetCommand()
        {
            var command = commands[0];
            commands.RemoveAt(0);
            return command;
        }
    }
}
