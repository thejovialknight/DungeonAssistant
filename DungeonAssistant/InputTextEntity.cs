using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAssistant
{
    class InputTextEntity : TextEntity
    {
        char[] cursorChars = { '|', '\\', '-', '/' };
        public double cooldownToCursorChange = 0.15f;

        double timeTillCursorChange = 0f;
        int currentCursorIndex = 0;
        string inputText = "";

        public InputTextEntity(string text, Position position, TextOverflowBehavior overflow, TextAlignment alignment)
        {
            this.text = text;
            this.position = position;
            overflowBehavior = overflow;
            this.alignment = alignment;
        }

        public override void Tick()
        {
            timeTillCursorChange -= Time.deltaTime;
            if(timeTillCursorChange <= 0f)
            {
                currentCursorIndex++;
                if (currentCursorIndex >= cursorChars.Length)
                    currentCursorIndex = 0;

                timeTillCursorChange = cooldownToCursorChange;
            }

            if(Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter)
                {
                    DMConsole.Output("|>" + inputText);

                    VConsole.SetCursorPosition(panel.position.x + 2, panel.position.y);
                    for (int i = panel.position.x + 2; i <= inputText.Length + 3; i++)
                    {
                        VConsole.Write(' ');
                    }

                    ConsoleCommandManager.instance.ParseCommand(inputText);
                    inputText = "";
                }
                else
                    inputText += key.KeyChar;
            }

            Draw();
        }

        public override void Draw()
        {
            VConsole.SetCursorPosition(panel.position.x + 2, panel.position.y);
            VConsole.Write(inputText);
            VConsole.Write(cursorChars[currentCursorIndex]);
        }
    }
}
