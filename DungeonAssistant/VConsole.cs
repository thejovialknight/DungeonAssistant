using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAssistant
{
    class VConsole
    {
        public static int x;
        public static int y;

        public static void SetCursorPosition(int x, int y)
        {
            VConsole.x = x;
            VConsole.y = y;
        }

        public static void Write(string str)
        {
            if(VConsole.x >= 0 && VConsole.y >= 0) // TODO: Also check if too big
            {
                Console.SetCursorPosition(x, y);
                Console.Write(str);
                VConsole.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            }
        }

        public static void Write(char character)
        {
            VConsole.Write(character.ToString());
        }
    }
}
