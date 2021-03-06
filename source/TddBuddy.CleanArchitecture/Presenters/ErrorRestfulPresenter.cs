﻿using System.Web.Http;
using TddBuddy.CleanArchitecture.Domain.Output;
using TddBuddy.CleanArchitecture.HttpResponses;

namespace TddBuddy.CleanArchitecture.Presenters
{
    public class ErrorRestfulPresenter<TError> : GenericRestfulPresenter, IRespondWith<TError>
         where TError : class
    {
        private readonly ApiController _controller;

        public ErrorRestfulPresenter(ApiController controller)
        {
            _controller = controller;
        }

        public void Respond(TError output)
        {
            RespondWith(new UnprocessasbleEntityResult<TError>(output, _controller));
        }
    }
}