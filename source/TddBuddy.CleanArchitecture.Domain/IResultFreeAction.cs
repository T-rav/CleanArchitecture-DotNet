using TddBuddy.CleanArchitecture.Domain.Messages;
using TddBuddy.CleanArchitecture.Domain.Output;

namespace TddBuddy.CleanArchitecture.Domain
{
    public interface IResultFreeAction<TInputTo>
    {
        void Execute(TInputTo inputTo, IRespondWithResultFreeSuccessOrError<ErrorOutputMessage> presenter);
    }
}
