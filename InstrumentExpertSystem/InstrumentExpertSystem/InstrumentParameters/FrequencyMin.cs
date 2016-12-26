
namespace InstrumentExpertSystem
{
    public class FrequencyMinParameter : InstrumentParameter
    {
        public float Frequency { get; set; }
        public override bool CompareWithInstrument(Instrument instrument)
        {
            return CompareWithToleration(Frequency, instrument.FrequencyMin);
        }
    }
}
