using System.Threading.Tasks;
using TddBuddy.CleanArchitecture.Domain.Output;
using TddBuddy.CleanArchitecture.Domain.TOs;

namespace TddBuddy.CleanArchitecture.Domain
{
    public interface IActionAsync<out IItOutputTo>
    {
        Task Execute(IRespondWithSuccessOrError<IItOutputTo, ErrorOutputTo> presenter);
    }
}
