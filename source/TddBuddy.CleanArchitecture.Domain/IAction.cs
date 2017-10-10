using TddBuddy.CleanArchitecture.Domain.Messages;
using TddBuddy.CleanArchitecture.Domain.Output;

namespace TddBuddy.CleanArchitecture.Domain
{
    public interface IAction<out TItOutputTo>
    {
        void Execute(IRespondWithSuccessOrError<TItOutputTo, ErrorOutputMessage> presenter);
    }
}
