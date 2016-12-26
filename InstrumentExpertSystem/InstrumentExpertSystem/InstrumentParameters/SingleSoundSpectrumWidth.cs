
namespace InstrumentExpertSystem
{
    public class SingleSoundSpectrumWidthParameter : InstrumentParameter
    {
        public float SpectrumWidth { get; set; }
        public override bool CompareWithInstrument(Instrument instrument)
        {
            return CompareWithToleration(SpectrumWidth, instrument.SingleSoundSpectrumWidth);
        }
    }
}
