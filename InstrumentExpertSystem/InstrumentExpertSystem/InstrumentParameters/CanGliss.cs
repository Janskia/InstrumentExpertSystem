
using System;

namespace InstrumentExpertSystem
{
    public class CanGliss : InstrumentParameter
    {
        public bool Can { get; set; }

        public override bool CompareWithInstrument(Instrument instrument)
        {
            return instrument.CanGliss == Can;
        }
    }
}
