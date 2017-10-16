using TddBuddy.CleanArchitecture.Domain.Output;

namespace TddBuddy.CleanArchitecture.Domain.Presenter
{
    public class ResultFreePropertyPresenter<TError> : IRespondWithNoResultSuccessOrError<TError>
    {
        public TError ErrorContent { get; private set; }

        public void Respond(TError output)
        {
            ErrorContent = output;
        }

        public void Respond()
        {

        }

        public bool IsErrorResponse()
        {
            return ErrorContent != null;
        }
    }
}
