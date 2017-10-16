namespace TddBuddy.CleanArchitecture.Domain.Output
{
    [System.Obsolete("IRespondWithNoResultSuccessOrError is deprecated, please use IRespondWithResultFreeSuccessOrError instead.")]
    public interface IRespondWithNoResultSuccessOrError<in TError> : IRespondWith<TError>
    {
        void Respond();
    }
}