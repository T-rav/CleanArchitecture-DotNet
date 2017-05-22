using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using TddBuddy.CleanArchitecture.Domain.Output;

namespace TddBuddy.CleanArchitecture.HttpResponses
{
    public class DownloadFileResult : IHttpActionResult
    {
        public IFileOutput FileOutput { get; }

        public DownloadFileResult(IFileOutput fileOutput)
        {
            if (fileOutput == null)
            {
                throw new ArgumentNullException(nameof(fileOutput));
            }

            FileOutput = fileOutput;
        }

        Task<HttpResponseMessage> IHttpActionResult.ExecuteAsync(CancellationToken cancellationToken)
        {
            var pushStreamContent = new PushStreamContent((outputStream, httpContent, transportContext) =>
            {
                FileOutput.Write(outputStream);
                outputStream.Flush();
                outputStream.Close();
            });

            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = pushStreamContent,
            };

            httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = FileOutput.FileName
            };

            return Task.FromResult(httpResponseMessage);
        }
    }
}