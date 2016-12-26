
using System;

namespace InstrumentExpertSystem
{
    public class CanModulateFrequencyParameter : InstrumentParameter
    {
        public bool CanModulateFrequency { get; set; }

        public override bool CompareWithInstrument(Instrument instrument)
        {
            return instrument.CanModulateFrequency == CanModulateFrequency;
        }
    }
}
