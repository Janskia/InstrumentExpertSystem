
namespace InstrumentExpertSystem
{
    public abstract class InstrumentParameter
    {
        protected readonly float toleration = 0.4f;
        public bool Enabled { get; set; }
        public abstract bool CompareWithInstrument(Instrument instrument);

        protected bool CompareWithToleration(float value1, float value2)
        {
            return (value1 < value2 * (1 + toleration)) && (value1 > value2 * (1 - toleration));
        }
    }
}
