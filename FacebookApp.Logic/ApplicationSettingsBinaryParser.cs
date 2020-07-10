using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FacebookApp.Logic
{
    // NOTE FOR CHECKER:
    // This class was used to test Template-Method Replaceability.
    internal class ApplicationSettingsBinaryParser : ApplicationSettingsParser
    {
        private readonly BinaryFormatter r_BinarySerializer;

        public ApplicationSettingsBinaryParser()
        {
            r_BinarySerializer = new BinaryFormatter();
        }

        public override ApplicationSettings Deserialize(Stream i_Stream)
        {
            ApplicationSettings result = r_BinarySerializer.Deserialize(i_Stream) as ApplicationSettings;
            return result;
        }

        public override void Serialize(Stream i_Stream, object i_Caller)
        {
            r_BinarySerializer.Serialize(i_Stream, i_Caller);
        }
    }
}
