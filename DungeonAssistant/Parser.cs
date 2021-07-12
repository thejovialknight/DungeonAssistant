using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAssistant
{
    class Parser
    {
        public static bool CompareInvariant(string s1, string s2)
        {
            return (s1.ToUpperInvariant() == s2.ToUpperInvariant());
        }
    }
}
