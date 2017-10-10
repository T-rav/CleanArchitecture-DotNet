using System;
using System.Web.Http;

namespace TddBuddy.CleanArchitecture.Presenters
{
    public class GenericRestfulPresenter
    {
        private IHttpActionResult _response;

        public void RespondWith(IHttpActionResult response)
        {
            _response = response;
        }

        public IHttpActionResult Render()
        {
            if (IsAnyResponsesSpecified())
            {
                return _response;
            }

            throw new InvalidOperationException("No response specified.");
        }

        private bool IsAnyResponsesSpecified()
        {
            return _response != null;
        }
    }
}