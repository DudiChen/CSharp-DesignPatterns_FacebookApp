using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.SqlServer.Server;

namespace FacebookApp.Logic
{
    internal abstract class ApplicationSettingsParser
    {
        public abstract ApplicationSettings Desirialize(Stream i_Stream);

        public abstract void Serialize(Stream i_Stream, object i_Caller);
    }

    internal class ApplicationSettingsXmlParser : ApplicationSettingsParser
    {
        private XmlSerializer xmlSerializer;

        public ApplicationSettingsXmlParser()
        {
            xmlSerializer = new XmlSerializer(typeof(ApplicationSettings));
        }

        public override ApplicationSettings Desirialize(Stream i_Stream)
        {
            ApplicationSettings result = xmlSerializer.Deserialize(i_Stream) as ApplicationSettings;
            return result;
        }

        public override void Serialize(Stream i_Stream, object i_Caller)
        {
            xmlSerializer.Serialize(i_Stream, i_Caller);
        }
    }

    internal class ApplicationSettingsBinaryParser : ApplicationSettingsParser
    {
        private BinaryFormatter binarySerializer;

        public ApplicationSettingsBinaryParser()
        {
            binarySerializer = new BinaryFormatter();
        }

        public override ApplicationSettings Desirialize(Stream i_Stream)
        {
            ApplicationSettings result = binarySerializer.Deserialize(i_Stream) as ApplicationSettings;
            return result;
        }

        public override void Serialize(Stream i_Stream, object i_Caller)
        {
            binarySerializer.Serialize(i_Stream, i_Caller);
        }
    }
}
