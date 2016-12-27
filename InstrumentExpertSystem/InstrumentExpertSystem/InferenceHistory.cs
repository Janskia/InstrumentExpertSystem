using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentExpertSystem
{
    public class InferenceHistory
    {
        public string History { get; private set; }

        public void Clear()
        {
            History = "";
        }
        public void AddLine(string newLine)
        {
            History += newLine + "\n";
        }

        internal void AddSeparator()
        {
            AddLine("---");
        }
    }
}
