using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAssistant
{
    class ConsoleCommand
    {
        public string id = "";
        public string[] args;
        public FieldArgument[] fieldArgs;

        public bool CheckArg(string[] arguments)
        {
            foreach(string arg in args)
            {
                foreach(string argument in arguments)
                {
                    if (Parser.CompareInvariant(arg, argument))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CheckArg(string argument)
        {
            return CheckArg(new string[] { argument });
        }

        public bool CheckField(string[] identifiers)
        {
            foreach(FieldArgument fieldArg in fieldArgs)
            {
                foreach(string identifier in identifiers)
                {
                    if (Parser.CompareInvariant(fieldArg.id, identifier))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CheckField(string identifier)
        {
            return CheckField(new string[] { identifier });
        }

        public string GetField(string[] identifiers)
        {
            foreach (FieldArgument fieldArg in fieldArgs)
            {
                foreach(string identifier in identifiers)
                {
                    if (Parser.CompareInvariant(fieldArg.id, identifier))
                    {
                        return fieldArg.parameter;
                    }
                }
            }

            return "";
        }

        public string GetField(string identifier)
        {
            return GetField(new string[] { identifier });
        }
    }
}
