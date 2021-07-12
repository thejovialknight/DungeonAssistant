using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAssistant
{
    class TextEntity : VisibleEntity
    {
        public string text;
        public TextOverflowBehavior overflowBehavior;
        public TextAlignment alignment; // TODO. Implement behavior.

        public TextEntity()
        {

        }

        public TextEntity(string text)
        {
            this.text = text;
            position = new Position { x = 0, y = 0 };
            overflowBehavior = TextOverflowBehavior.Wrap;
            this.alignment = TextAlignment.Left;
        }

        public TextEntity(string text, TextOverflowBehavior overflow)
        {
            this.text = text;
            position = new Position { x = 0, y = 0 };
            overflowBehavior = overflow;
            this.alignment = TextAlignment.Left;
        }

        public TextEntity(string text, Position position, TextOverflowBehavior overflow, TextAlignment alignment)
        {
            this.text = text;
            this.position = position;
            overflowBehavior = overflow;
            this.alignment = alignment;
        }

        void DrawToken(string token)
        {
            foreach (char character in token)
            {
                bool isDrawingCharacter = true;

                if (character == '\n')
                {
                    VConsole.SetCursorPosition(panel.position.x + position.x, VConsole.y + 1);
                    isDrawingCharacter = false;
                }

                if (VConsole.x > panel.position.x + panel.scale.width)
                {
                    if (overflowBehavior == TextOverflowBehavior.Wrap)
                        VConsole.SetCursorPosition(panel.position.x + position.x, VConsole.y + 1);
                }

                // check for inside panel
                if (VConsole.x >= panel.position.x + panel.scale.width)
                    isDrawingCharacter = false;
                if (VConsole.x < panel.position.x)
                    isDrawingCharacter = false;
                if (VConsole.y >= panel.position.y + panel.scale.height)
                    isDrawingCharacter = false;
                if (VConsole.y < panel.position.y)
                    isDrawingCharacter = false;

                if (isDrawingCharacter)
                {
                    VConsole.Write(character);
                }
                else
                {
                    if(character != '\n')
                        VConsole.SetCursorPosition(VConsole.x + 1, VConsole.y);
                }
            }
        }

        public override void Draw()
        {
            base.Draw();

            VConsole.SetCursorPosition(panel.position.x + position.x, panel.position.y + position.y);

            string[] tokens = text.Split(' ');

            foreach(string token in tokens)
            {
                // if the word will be too big to print
                if (VConsole.x + token.Length > panel.position.x + panel.scale.width)
                {
                    if (overflowBehavior == TextOverflowBehavior.Wrap)
                        VConsole.SetCursorPosition(panel.position.x, VConsole.y + 1);
                }

                DrawToken(token);

                if(VConsole.x != panel.position.x + position.x)
                    DrawToken(" ");
            }
        }
    }

    enum TextOverflowBehavior
    {
        Cutoff,
        Wrap
    }

    enum TextAlignment
    {
        Left,
        Center,
        Right
    }
}
