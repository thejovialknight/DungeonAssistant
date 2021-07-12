using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAssistant
{
    class ConsoleCommandManager
    {
        public List<CommandHandlerEntity> commandHandlers = new List<CommandHandlerEntity>();

        public static ConsoleCommandManager instance;

        public ConsoleCommandManager()
        {
            instance = this;
        }

        public void ParseCommand(string txt)
        {
            ConsoleCommand command = new ConsoleCommand();
            string id = "";
            string currentArg = "";
            string currentArgParameter = "";
            FieldArgument currentFieldArg = new FieldArgument();
            List<string> args = new List<string>();
            List<FieldArgument> fieldArgs = new List<FieldArgument>();
            ParserState state = ParserState.ID;

            for (int i = 0; i < txt.Length; i++)
            {
                if(state == ParserState.ID)
                {
                    if(txt[i] == ' ')
                    {
                        state = ParserState.Arg;
                    }
                    else if(txt[i] == '(')
                    {
                        currentFieldArg.id = id;
                        state = ParserState.ArgParameter;
                    }
                    else
                    {
                        id += txt[i];
                    }
                }
                else if(state == ParserState.Arg)
                {
                    if (txt[i] == ' ')
                    {
                        args.Add(currentArg);
                        currentArg = "";
                    }
                    else if (txt[i] == '(')
                    {
                        currentFieldArg.id = currentArg;
                        state = ParserState.ArgParameter;
                    }
                    else
                    {
                        currentArg += txt[i];
                    }
                }
                else if(state == ParserState.ArgParameter)
                {
                    if(txt[i] == ')')
                    {
                        currentFieldArg.parameter = currentArgParameter;
                        fieldArgs.Add(currentFieldArg);
                        currentFieldArg = new FieldArgument();
                        currentArg = "";
                        currentArgParameter = "";
                        state = ParserState.WaitingForArg;
                    }
                    else
                    {
                        currentArgParameter += txt[i];
                    }
                }
                else if(state == ParserState.WaitingForArg)
                {
                    if(txt[i] != ' ')
                    {
                        currentArg += txt[i];
                        state = ParserState.Arg;
                    }
                }
            }

            if(state == ParserState.Arg)
            {
                args.Add(currentArg);
            }
            else if (state == ParserState.ArgParameter)
            {
                currentFieldArg.parameter = currentArgParameter;
            }

            command.id = id;
            command.args = args.ToArray();
            command.fieldArgs = fieldArgs.ToArray();

            DelegateCommand(command);
        }

        public void DelegateCommand(ConsoleCommand command)
        {
            foreach (CommandHandlerEntity handler in commandHandlers)
            {
                foreach(string id in handler.commandIdentifiers)
                {
                    if (Parser.CompareInvariant(id, command.id))
                    {
                        handler.Command(command);
                    }
                }
            }
        }
    }

    enum ParserState
    {
        ID,
        Arg,
        ArgParameter,
        WaitingForArg
    }
}
