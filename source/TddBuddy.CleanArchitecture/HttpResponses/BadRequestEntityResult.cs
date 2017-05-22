using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Results;

namespace TddBuddy.CleanArchitecture.HttpResponses
{
    public class BadRequestEntityResult<T> : NegotiatedContentResult<T>
    {
        private const HttpStatusCode BadRequestHttpStatusCode = HttpStatusCode.BadRequest;

        public BadRequestEntityResult(T content, IContentNegotiator contentNegotiator, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters) : base(BadRequestHttpStatusCode, content, contentNegotiator, request, formatters)
        {
        }

        public BadRequestEntityResult(T content, ApiController controller) : base(BadRequestHttpStatusCode, content, controller)
        {
        }
    }
}
