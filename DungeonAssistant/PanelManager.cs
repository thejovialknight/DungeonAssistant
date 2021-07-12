using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAssistant
{
    class PanelManager
    {
        public ConsoleCommandManager commandManager;
        public List<Panel> panels = new List<Panel>();

        public PanelManager()
        {
            CreateConsole();
            CreateHUD();
            DrawPanels();
        }

        public void Tick()
        {
            TickPanels();
        }

        public void CreateHUD()
        {
            Panel hudPanel = new Panel(true, new Position { x = 1, y = 1 }, new Scale { width = 122, height = 1});
            hudPanel.AddEntity(new TextEntity("12:00 AM, Monday, 4th of Tristar | The Dirging Dungaree, Thaymor | The Hunt for the Aevenstar", TextOverflowBehavior.Cutoff));

            panels.Add(hudPanel);
        }

        public void CreateConsole()
        {
            commandManager = new ConsoleCommandManager();

            Panel consolePanel = new Panel(true, new Position { x = 1, y = 4 }, new Scale { height = 28, width = 60 });
            DMConsole consoleBox = new DMConsole();
            consolePanel.AddEntity(consoleBox);
            panels.Add(consolePanel);

            Panel inputPanel = new Panel(true, new Position { x = 1, y = 34 }, new Scale { width = 122, height = 1 });
            TextEntity inputCursor = new TextEntity("|>", new Position { x = 0, y = 0 }, TextOverflowBehavior.Cutoff, TextAlignment.Left);
            InputTextEntity inputBox = new InputTextEntity(" ", new Position { x = 2, y = 0 }, TextOverflowBehavior.Cutoff, TextAlignment.Left);
            inputPanel.AddEntity(inputCursor);
            inputPanel.AddEntity(inputBox);
            panels.Add(inputPanel);

            // DEBUG COMMAND HANDLER
            consolePanel.AddEntity(new DebugCommandHandler());
        }

        public void TickPanels()
        {
            foreach (Panel panel in panels)
            {
                panel.Tick();
            }
        }

        public void DrawPanels()
        {
            foreach (Panel panel in panels)
            {
                panel.Draw();
            }
        }
    }
}
