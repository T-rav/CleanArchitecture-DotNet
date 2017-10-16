namespace TddBuddy.CleanArchitecture.Domain.Output
{
    public interface IRespondWithResultFreeSuccessOrError<in TError> : IRespondWith<TError>
    {
        void Respond();
    }
}