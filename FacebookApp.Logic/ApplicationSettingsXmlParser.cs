using System.IO;
using System.Xml.Serialization;

namespace FacebookApp.Logic
{
    internal class ApplicationSettingsXmlParser : ApplicationSettingsParser
    {
        private XmlSerializer xmlSerializer;

        public ApplicationSettingsXmlParser()
        {
            xmlSerializer = new XmlSerializer(typeof(ApplicationSettings));
        }

        public override ApplicationSettings Deserialize(Stream i_Stream)
        {
            ApplicationSettings result = xmlSerializer.Deserialize(i_Stream) as ApplicationSettings;
            return result;
        }

        public override void Serialize(Stream i_Stream, object i_Caller)
        {
            xmlSerializer.Serialize(i_Stream, i_Caller);
        }
    }
}
