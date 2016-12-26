
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace InstrumentExpertSystem
{
    static class KnowledgeBaseSerialization
    {
        public static KnowledgeBase LoadKnowledgeBase(string fileName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            string xmlString = xmlDocument.OuterXml;
            KnowledgeBase knowledgeBase;

            using (StringReader read = new StringReader(xmlString))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(KnowledgeBase));
               
                using (XmlReader reader = new XmlTextReader(read))
                {
                    knowledgeBase = (KnowledgeBase)serializer.Deserialize(reader);
                    reader.Close();
                }

                read.Close();
            }
            return knowledgeBase;
        }

        public static void SaveKnowledgeBase(KnowledgeBase knowledgeBase, string fileName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(knowledgeBase.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, knowledgeBase);
                stream.Position = 0;
                xmlDocument.Load(stream);
                xmlDocument.Save(fileName);
                stream.Close();
            }
        }
    }
}
