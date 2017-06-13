using System.IO;
using TddBuddy.CleanArchitecture.Domain.Output;

namespace TddBuddy.CleanArchitecture.Domain.Messages
{
    public class InMemoryFileOutputMessage : IFileOutput
    {
        private readonly byte[] _fileData;
        public string FileName { get; }

        public InMemoryFileOutputMessage(string fileName, byte[] fileData)
        {
            _fileData = fileData;
            FileName = fileName;
        }

        public void Write(Stream outputStream)
        {
            using (var dataStream = new MemoryStream(_fileData))
            {
                dataStream.CopyTo(outputStream);
            }
        }
    }
}