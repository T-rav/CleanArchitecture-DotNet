using TddBuddy.CleanArchitecture.Domain.Messages;
using TddBuddy.CleanArchitecture.Domain.Output;

namespace TddBuddy.CleanArchitecture.Domain
{
    public interface IAction<IItOutputTo>
    {
        void Execute(IRespondWithSuccessOrError<IItOutputTo, ErrorOutputMessage> presenter);
    }
}
