using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAssistant
{
    class Time
    {
        public static double deltaTime = 0;
        static double lastFrameTime = 0;

        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static void Tick()
        {
            double now = DateTime.Now.ToUniversalTime().Subtract(Epoch).TotalSeconds;
            deltaTime = (now - lastFrameTime);
            lastFrameTime = now;
        }
    }
}
