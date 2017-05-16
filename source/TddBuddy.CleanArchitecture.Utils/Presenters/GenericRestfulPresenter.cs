using System;
using System.Diagnostics;
using System.Web.Http;
using System.Web.Http.Results;
using TddBuddy.CleanArchitecture.Utils.HttpResponses;

namespace TddBuddy.CleanArchitecture.Utils.Presenters
{
    public class GenericRestfulPresenter<TOkContent, TUnprocessableEntity>
        where TOkContent : class
        where TUnprocessableEntity : class
    {
        private readonly ApiController _controller;
        private TOkContent _okContent;
        private TUnprocessableEntity _unprocessableEntityContent;
        private bool _blankOkResponse;
        private Action<GenericRestfulPresenter<TOkContent, TUnprocessableEntity>> _defaultResponse;
        private TUnprocessableEntity _forbiddenContent;

        public GenericRestfulPresenter(ApiController controller)
        {
            _controller = controller;
        }

        public GenericRestfulPresenter<TOkContent, TUnprocessableEntity> DefaultResponse(Action<GenericRestfulPresenter<TOkContent, TUnprocessableEntity>> defaultResponse)
        {
            _defaultResponse = defaultResponse;
            return this;
        }

        public void RespondWithOk(TOkContent content)
        {
            _okContent = content;
        }

        public void RespondWithOk()
        {
            _blankOkResponse = true;
        }

        public void RespondWithUnprocessableEntity(TUnprocessableEntity content)
        {
            _unprocessableEntityContent = content;
        }

        public IHttpActionResult Render()
        {
            CheckForMultipleResponses();

            if (!IsAnyResponsesSpecified())
            {
                _defaultResponse?.Invoke(this);
            }

            if (IsUnprocessableResponse())
            {
                return CreateUnprocessableEntityResult();
            }

            if (IsForbiddenResponse())
            {
                return CreateForbiddenResult();
            }

            if (IsOkResponse())
            {
                return CreateOkResult();
            }

            throw new InvalidOperationException("No response specified.");
        }

        private IHttpActionResult CreateForbiddenResult()
        {
            return new ForbiddenEntityResult<TUnprocessableEntity>(_forbiddenContent, _controller);
        }

        private IHttpActionResult CreateUnprocessableEntityResult()
        {
            return new UnprocessasbleEntityResult<TUnprocessableEntity>(_unprocessableEntityContent, _controller);
        }

        private IHttpActionResult CreateOkResult()
        {
            if (_blankOkResponse)
            {
                return new OkResult(_controller);
            }

            return new OkNegotiatedContentResult<TOkContent>(_okContent, _controller);
        }

        private bool IsOkResponse()
        {
            return _okContent != null || _blankOkResponse;
        }

        private bool IsUnprocessableResponse()
        {
            return _unprocessableEntityContent != null;
        }

        private bool IsForbiddenResponse()
        {
            return _forbiddenContent != null;
        }

        private bool IsAnyResponsesSpecified()
        {
            return IsUnprocessableResponse() || IsOkResponse();
        }

        private void CheckForMultipleResponses()
        {
            if (IsUnprocessableResponse() && IsOkResponse())
            {
                throw new InvalidOperationException("Only one response allowed.");
            }
        }

        protected void RespondWithForbidden(TUnprocessableEntity output)
        {
            _forbiddenContent = output;
        }
    }
}