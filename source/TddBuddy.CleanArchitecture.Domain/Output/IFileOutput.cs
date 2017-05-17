using System.IO;

namespace TddBuddy.CleanArchitecture.Domain.Output
{
    public interface IFileOutput
    {
        string FileName { get; }
        void Write(Stream outputStream);
    }
}