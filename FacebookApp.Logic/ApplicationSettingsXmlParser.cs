using System.IO;
using System.Xml.Serialization;

namespace FacebookApp.Logic
{
    internal class ApplicationSettingsXmlParser : ApplicationSettingsParser
    {
        private readonly XmlSerializer r_XmlSerializer;

        public ApplicationSettingsXmlParser()
        {
            r_XmlSerializer = new XmlSerializer(typeof(ApplicationSettings));
        }

        public override ApplicationSettings Deserialize(Stream i_Stream)
        {
            ApplicationSettings result = r_XmlSerializer.Deserialize(i_Stream) as ApplicationSettings;
            return result;
        }

        public override void Serialize(Stream i_Stream, object i_Caller)
        {
            r_XmlSerializer.Serialize(i_Stream, i_Caller);
        }
    }
}
