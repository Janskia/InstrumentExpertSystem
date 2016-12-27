
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace InstrumentExpertSystem
{
    [Serializable]
    public class KnowledgeBase
    {
        [XmlIgnore]
        public InferenceHistory InferenceHistory { get; set; }
        public KnowledgeBase()
        {
            Instruments = new List<Instrument>();
        }
        public KnowledgeBase(InferenceHistory inferenceHistory)
        {
            Instruments = new List<Instrument>();
            this.InferenceHistory = inferenceHistory;
        }

        [XmlArray]
        public List<Instrument> Instruments { get; set; }

        public List<Instrument> FindInstrumentsWithSpecifiedparameters(List<InstrumentParameter> parameters)
        {
            List<Instrument> availableInstruments = new List<Instrument>(Instruments);
            foreach (InstrumentParameter parameter in parameters)
            {
                InferenceHistory.AddSeparator();
                InferenceHistory.AddLine("Cheking parameter: " + parameter.ToString());

                List<Instrument> newAvailableInstruments = new List<Instrument>(availableInstruments);
                foreach (Instrument instrument in availableInstruments)
                {
                    if (!parameter.CompareWithInstrument(instrument))
                    {
                        newAvailableInstruments.Remove(instrument);
                        InferenceHistory.AddLine(instrument.Name + " does not fulfill condition");
                    }
                }
                availableInstruments = newAvailableInstruments;
                InferenceHistory.AddSeparator();
                InferenceHistory.AddLine("Instruments left: ");
                foreach (Instrument instrument in availableInstruments)
                {
                    InferenceHistory.AddLine(instrument.Name);
                }
            }
            return availableInstruments;
        }
    }
}
