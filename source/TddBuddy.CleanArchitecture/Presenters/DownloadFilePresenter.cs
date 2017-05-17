using System;
using System.Web.Http;
using TddBuddy.CleanArchitecture.Domain.Output;
using TddBuddy.CleanArchitecture.Domain.TOs;
using TddBuddy.CleanArchitecture.HttpResponses;

namespace TddBuddy.CleanArchitecture.Presenters
{
    public class DownloadFilePresenter : IRespondWithSuccessOrError<IFileOutput, ErrorOutputTo>, IRespondWith<IFileOutput>
    {
        private readonly ApiController _controller;
        private IFileOutput _fileContent;
        private ErrorOutputTo _errorContent;

        public DownloadFilePresenter(ApiController controller)
        {
            _controller = controller;
        }

        public void Respond(IFileOutput fileOutput)
        {
            _fileContent = fileOutput;
        }

        public void Respond(ErrorOutputTo output)
        {
            _errorContent = output;
        }

        public IHttpActionResult Render()
        {
            if (IsErrorResponse() && IsFileResponse())
            {
                throw new InvalidOperationException("Only one response allowed");
            }

            if (!IsErrorResponse() && !IsFileResponse())
            {
                throw new InvalidOperationException("No response specified");
            }

            if (IsErrorResponse())
            {
                return new UnprocessasbleEntityResult<ErrorOutputTo>(_errorContent, _controller);
            }

            return new DownloadFileResult(_fileContent);
        }

        private bool IsFileResponse()
        {
            return _fileContent != null;
        }

        private bool IsErrorResponse()
        {
            return _errorContent != null;
        }
    }
}