using BancoApp.Domain.Factories;

namespace BancoApp.Domain.Operations.Statement
{
    public class StatementOperation : IOperation<StatementCommand, IEnumerable<string>>
    {
        private readonly IBankFactory _bankFactory;

        public StatementOperation(IBankFactory bankFactory)
        {
            _bankFactory = bankFactory;
        }

        public IEnumerable<string> Execute(StatementCommand command)
        {
            return _bankFactory
                .Create(command.BankNumber)
                .ReadStatement(command.AccountNumber);
        }
    }
}
