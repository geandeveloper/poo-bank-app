using BancoApp.Domain.Factories;

namespace BancoApp.Domain.Operations.Withdraw
{
    public class WithdrawOperation : IOperation<WithdrawCommand, Task>
    {
        private readonly IBankFactory _bankFactory;

        public WithdrawOperation(IBankFactory bankFactory)
        {
            _bankFactory = bankFactory;
        }

        public Task Execute(WithdrawCommand command)
        {
            var banco = _bankFactory.Create(command.BankNumber);
            banco.Withdraw(command.AccountNumber, command.Amount);
            return Task.CompletedTask;
        }
    }
}
