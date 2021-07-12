using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAssistant
{
    class Panel
    {
        // border goes around the scale and position, not included.
        public Position position;
        public Scale scale;
        public char topBorderCharacter;
        public char sideBorderCharacter;
        public bool isOpen = true;

        public List<Entity> entities = new List<Entity>();

        public void Tick()
        {
            foreach(Entity entity in entities)
            {
                entity.Tick();
            }
        }

        public Panel(bool isOpen, Position position, Scale scale)
        {
            this.isOpen = isOpen;
            this.position = position;
            this.scale = scale;
            topBorderCharacter = '═';
            sideBorderCharacter = '║';
        }

        public Entity AddEntity(Entity entity)
        {
            entities.Add(entity);
            entity.panel = this;
            entity.Instantiate();
            return entity;
        }

        public void Resize(Scale scale)
        {
            this.scale = scale;
            Draw();
        }

        public void Draw()
        {
            DrawBorder();
            Clear();

            foreach(Entity entity in entities)
            {
                entity.Draw();
            }
        }

        public void Clear()
        {
            VConsole.SetCursorPosition(position.x, position.y);

            for (int i = 0; i < scale.height; i++)
            {
                for(int j = 0; j < scale.width; j++)
                {
                    VConsole.Write(' ');
                }

                VConsole.SetCursorPosition(position.x, VConsole.y + 1);
            }
        }

        public void DrawBorder()
        {
            VConsole.SetCursorPosition(position.x - 1, position.y - 1);
            DrawBorderCap('╔', '╗');

            for (int i = 0; i < scale.height; i++)
            {
                DrawBorderRow();
            }

            DrawBorderCap('╚', '╝');
        }

        public void DrawBorderRow()
        {
            VConsole.Write(sideBorderCharacter);

            VConsole.SetCursorPosition(position.x + scale.width, VConsole.y);

            VConsole.Write(sideBorderCharacter);

            VConsole.SetCursorPosition(position.x - 1, VConsole.y + 1);
        }

        public void DrawBorderCap(char start, char end)
        {
            VConsole.Write(start);

            for (int i = 0; i < scale.width; i++)
            {
                VConsole.Write(topBorderCharacter);
            }

            VConsole.Write(end);

            VConsole.SetCursorPosition(position.x - 1, VConsole.y + 1);
        }
    }
}
