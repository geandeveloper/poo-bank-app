using BancoApp.Domain.Models.Enums;

namespace BancoApp.Domain.Operations.Withdraw
{
    public record WithdrawCommand(BankNumberEnum BankNumber, string AccountNumber, decimal Amount);
}
