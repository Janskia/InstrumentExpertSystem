
namespace InstrumentExpertSystem
{
    public class IsMelodicParameter : InstrumentParameter
    {
        public bool IsMelodic { get; set; }
        public override bool CompareWithInstrument(Instrument instrument)
        {
            return IsMelodic == instrument.IsMelodic;
        }
    }
}
