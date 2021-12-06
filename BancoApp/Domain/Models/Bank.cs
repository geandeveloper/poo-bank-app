namespace BancoApp.Domain.Models;

using BancoApp.Domain.Models.Enums;
using BancoApp.Shared.Extensions;

public abstract class Bank
{
    public BankNumberEnum Number { get; private set; }
    public IEnumerable<Account> Accounts { get; private set; }
    protected abstract decimal Tax { get; }

    public Bank(BankNumberEnum numero, IEnumerable<Account> contas)
    {
        Number = numero;
        Accounts = contas;
    }

    public void Withdraw(string numeroConta, decimal total)
    {
        var conta = Accounts
            .FirstOrDefault(c => c.Number == numeroConta)
            .OrThrow("conta invalida");

        var totalWithdraw = total + Tax;

        if (!conta.HaveEnoughBalance(totalWithdraw))
            throw new Exception("Saldo insuficiente");

        conta.Withdraw(total, "Saque");
        conta.Withdraw(Tax, "Taxa de Saque");
    }

    public IEnumerable<string> ReadStatement(string numeroConta)
    {
        return Accounts
            .FirstOrDefault(c => c.Number == numeroConta)
            .OrThrow("conta invalida")
            .Statement;
    }
}

