
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace InstrumentExpertSystem
{
    [Serializable]
    public class KnowledgeBase
    {
        public KnowledgeBase()
        {
            Instruments = new List<Instrument>();
        }

        [XmlArray]
        public List<Instrument> Instruments { get; set; }

        public List<Instrument> FindInstrumentsWithSpecifiedparameters(List<InstrumentParameter> parameters)
        {
            List<Instrument> availableInstruments = new List<Instrument>(Instruments);
            foreach (InstrumentParameter parameter in parameters)
            {
                List<Instrument> newAvailableInstruments = new List<Instrument>(availableInstruments);
                foreach (Instrument instrument in availableInstruments)
                {
                    if (!parameter.CompareWithInstrument(instrument))
                    {
                        newAvailableInstruments.Remove(instrument);
                    }
                }
                availableInstruments = newAvailableInstruments;
            }
            return availableInstruments;
        }
    }
}
