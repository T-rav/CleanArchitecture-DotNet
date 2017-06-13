using TddBuddy.CleanArchitecture.Domain.Messages;
using TddBuddy.CleanArchitecture.Domain.Output;

namespace TddBuddy.CleanArchitecture.Domain
{
    public interface IUseCase<in TInputTo, out TItOutputTo>
    {
        void Execute(TInputTo inputTo, IRespondWithSuccessOrError<TItOutputTo, ErrorOutputMessage> presenter);
    }
}
