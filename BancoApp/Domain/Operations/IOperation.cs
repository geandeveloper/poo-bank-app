namespace BancoApp.Domain.Operations
{
    public interface IOperation<TCommand, TResult>
    {
        TResult Execute(TCommand command);
    }
}
