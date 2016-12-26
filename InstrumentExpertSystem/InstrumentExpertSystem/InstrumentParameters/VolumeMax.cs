
namespace InstrumentExpertSystem
{
    public class VolumeMaxParameter : InstrumentParameter
    {
        public float Volume { get; set; }
        public override bool CompareWithInstrument(Instrument instrument)
        {
            return CompareWithToleration(Volume, instrument.VolumeMax);
        }
    }
}
