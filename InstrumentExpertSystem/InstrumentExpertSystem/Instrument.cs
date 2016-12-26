namespace InstrumentExpertSystem
{
    public class Instrument
    {
        public string Name { get; set; }
        public float FrequencyMin { get; set; }
        public float FrequencyMax { get; set; }
        public float VolumeMin { get; set; }
        public float VolumeMax { get; set; }
        public bool CanGliss { get; set; }
        public EnvelopeType EnvelopeType { get; set; }
        public float SingleSoundSpectrumWidth { get; set; }
        public bool CanModulateFrequency { get; set; }
        public float AverageSoundDuration { get; set; }
        public bool IsMelodic { get; set; }
    }
}
