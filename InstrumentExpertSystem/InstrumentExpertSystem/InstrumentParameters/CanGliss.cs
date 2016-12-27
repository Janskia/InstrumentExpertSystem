
using System;

namespace InstrumentExpertSystem
{
    public class CanGlissParameter : InstrumentParameter
    {
        public bool Can { get; set; }

        public override bool CompareWithInstrument(Instrument instrument)
        {
            return instrument.CanGliss == Can;
        }
    }
}
