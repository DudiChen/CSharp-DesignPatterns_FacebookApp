using System.IO;

namespace FacebookApp.Logic
{
    internal abstract class ApplicationSettingsParser
    {
        public abstract ApplicationSettings Deserialize(Stream i_Stream);

        public abstract void Serialize(Stream i_Stream, object i_Caller);
    }
}
