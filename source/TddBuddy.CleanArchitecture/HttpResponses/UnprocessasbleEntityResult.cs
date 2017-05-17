using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Results;

namespace TddBuddy.CleanArchitecture.HttpResponses
{
    public class UnprocessasbleEntityResult<T> : NegotiatedContentResult<T>
    {
        private const HttpStatusCode UnprocessableEntityHttpStatusCode = (HttpStatusCode)422;

        public UnprocessasbleEntityResult(T content, IContentNegotiator contentNegotiator, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters) :
            base(UnprocessableEntityHttpStatusCode, content, contentNegotiator, request, formatters)
        {
        }

        public UnprocessasbleEntityResult(T content, ApiController controller) :
            base(UnprocessableEntityHttpStatusCode, content, controller)
        {
        }
    }
}