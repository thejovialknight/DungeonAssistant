using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAssistant
{
    class DMConsole : TextEntity
    {
        public List<string> outputs = new List<string>();

        public static DMConsole instance;

        public DMConsole()
        {
            instance = this;
            this.text = "";
            this.position = new Position { x = 0, y =0 };
            overflowBehavior = TextOverflowBehavior.Wrap;
            this.alignment = TextAlignment.Left; ;
        }

        public static void Output(string output)
        {
            instance.outputs.Add(output);

            instance.text = "";
            foreach(string str in instance.outputs)
            {
                instance.text += str + " \n ";
            }

            instance.Draw();
        }
    }
}
