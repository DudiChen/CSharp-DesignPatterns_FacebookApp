using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FacebookApp.Logic
{
    /// <summary>
    /// NOTE FOR CHECKER:
    /// This class was used to test Template-Method replaceabillity.
    /// </summary>
    internal class ApplicationSettingsBinaryParser : ApplicationSettingsParser
    {
        private BinaryFormatter binarySerializer;

        public ApplicationSettingsBinaryParser()
        {
            binarySerializer = new BinaryFormatter();
        }

        public override ApplicationSettings Deserialize(Stream i_Stream)
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
