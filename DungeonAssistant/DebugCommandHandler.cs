using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAssistant
{
    class DebugCommandHandler : CommandHandlerEntity
    {
        public override void Instantiate()
        {
            base.Instantiate();
            commandIdentifiers = new string[] { "print", "p", "message" };
        }

        public override void Command(ConsoleCommand command)
        {
            string commandString = "";

            string[] stringFieldNames = new string[] { "str", "string", "text", "print", "p", "message" };
            if (command.CheckField(stringFieldNames.Concat(commandIdentifiers).ToArray()))
            {
                commandString = command.GetField(stringFieldNames);
            }

            string[] upperFieldNames = new string[] { "upper", "up" };
            if (command.CheckArg(upperFieldNames))
            {
                commandString = commandString.ToUpper();
            }

            DMConsole.Output("Hello, your string is '" + commandString + "'");
        }
    }
}
