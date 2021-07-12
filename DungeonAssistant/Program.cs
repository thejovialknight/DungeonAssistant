using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAssistant
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(128, 36);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            PanelManager panels = new PanelManager();

            bool isRunning = true;
            while(isRunning)
            {
                Time.Tick();
                panels.Tick();
            }
        }
    }
}
