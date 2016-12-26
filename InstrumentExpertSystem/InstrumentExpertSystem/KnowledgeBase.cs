
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
    }
}
