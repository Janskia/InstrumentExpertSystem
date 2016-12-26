
using System;

namespace InstrumentExpertSystem
{
    public class AverageSoundDurationParameter : InstrumentParameter
    {
        public float AverageSoundDuration { get; set; }

        public override bool CompareWithInstrument(Instrument instrument)
        {
            return CompareWithToleration(AverageSoundDuration, instrument.AverageSoundDuration);
        }
    }
}
