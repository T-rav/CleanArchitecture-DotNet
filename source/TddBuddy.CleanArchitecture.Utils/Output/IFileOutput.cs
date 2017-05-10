using System.IO;

namespace CleanArchitecture.Utils.Output
{
    public interface IFileOutput
    {
        string FileName { get; }
        void Write(Stream outputStream);
    }
}