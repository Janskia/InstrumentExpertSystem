
namespace InstrumentExpertSystem
{
    public class FrequencyMaxParameter : InstrumentParameter
    {
        public float Frequency { get; set; }
        public override bool CompareWithInstrument(Instrument instrument)
        {
            return CompareWithToleration(Frequency, instrument.FrequencyMax);
        }
    }
}
