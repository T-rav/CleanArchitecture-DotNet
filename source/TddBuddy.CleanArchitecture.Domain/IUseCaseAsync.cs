using System.Threading.Tasks;
using TddBuddy.CleanArchitecture.Domain.Messages;
using TddBuddy.CleanArchitecture.Domain.Output;

namespace TddBuddy.CleanArchitecture.Domain
{
    public interface IUseCaseAsync<in TInputTo, out TItOutputTo>
    {
        Task Execute(TInputTo inputTo, IRespondWithSuccessOrError<TItOutputTo, ErrorOutputMessage> presenter);
    }
}
