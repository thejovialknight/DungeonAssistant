using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAssistant
{
    class CommandHandlerEntity : Entity
    {
        public string[] commandIdentifiers;

        public override void Instantiate()
        {
            base.Instantiate();
            ConsoleCommandManager.instance.commandHandlers.Add(this);
        }

        public override void Deinstantiate()
        {
            base.Deinstantiate();

        }

        public virtual void Command(ConsoleCommand command)
        {

        }
    }
}
