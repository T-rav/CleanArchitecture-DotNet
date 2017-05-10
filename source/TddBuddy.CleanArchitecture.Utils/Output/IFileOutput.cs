using System.IO;

namespace TddBuddy.CleanArchitecture.Utils.Output
{
    public interface IFileOutput
    {
        string FileName { get; }
        void Write(Stream outputStream);
    }
}