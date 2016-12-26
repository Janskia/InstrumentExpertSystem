
namespace InstrumentExpertSystem
{
    public class VolumeMinParameter : InstrumentParameter
    {
        public float Volume { get; set; }

        public override bool CompareWithInstrument(Instrument instrument)
        {
            return CompareWithToleration(Volume, instrument.VolumeMin);
        }
    }
}
