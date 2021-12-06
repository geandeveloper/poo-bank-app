using BancoApp.Domain.Operations.Statement;
using BancoApp.Domain.Operations.Withdraw;

namespace BancoApp.Domain.Operations
{
    public class BankOperations
    {
        public WithdrawOperation Withdraw { get; }
        public StatementOperation Statement { get; }

        public BankOperations(WithdrawOperation withdraw, StatementOperation statement)
        {
            Withdraw = withdraw;
            Statement = statement;
        }
    }
}
