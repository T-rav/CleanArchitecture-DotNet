using System.IO;
using CleanArchitecture.Utils.Output;

namespace CleanArchitecture.Utils.TOs
{
    public class InMemoryFileOutputTo : IFileOutput
    {
        private readonly byte[] _fileData;
        public string FileName { get; }

        public InMemoryFileOutputTo(string fileName, byte[] fileData)
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