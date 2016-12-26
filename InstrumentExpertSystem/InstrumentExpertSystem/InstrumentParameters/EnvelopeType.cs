
namespace InstrumentExpertSystem
{
    public class EnvelopeTypeParameter : InstrumentParameter
    {
        public EnvelopeType EnvelopeType { get; set; }
        public override bool CompareWithInstrument(Instrument instrument)
        {
            return instrument.EnvelopeType == EnvelopeType;
        }
    }
}
