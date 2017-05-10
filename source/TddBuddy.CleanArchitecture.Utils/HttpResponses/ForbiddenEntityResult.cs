using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Results;

namespace TddBuddy.CleanArchitecture.Utils.HttpResponses
{
    public class ForbiddenEntityResult<T> : NegotiatedContentResult<T>
    {
        private const HttpStatusCode ForbiddenHttpStatusCode = HttpStatusCode.Forbidden;

        public ForbiddenEntityResult(T content, IContentNegotiator contentNegotiator, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters) :
            base(ForbiddenHttpStatusCode, content, contentNegotiator, request, formatters)
        {
        }

        public ForbiddenEntityResult(T content, ApiController controller) :
            base(ForbiddenHttpStatusCode, content, controller)
        {
        }
    }
}