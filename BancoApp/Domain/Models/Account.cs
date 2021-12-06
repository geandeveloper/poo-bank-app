namespace BancoApp.Domain.Models;

public class Account
{
    public string Number { get; private set; }
    public decimal Balance { get; private set; }
    public List<string> Statement { get; private set; }

    public Account(string number, decimal balance)
    {
        Number = number;
        Balance = balance;
        Statement = new List<string>();
    }

    public void Withdraw(decimal total, string description)
    {
        Balance -= total;
        Statement.Add($"Operação: {description} Valor: {total}, Saldo em conta: {Balance}");
    }

    public bool HaveEnoughBalance(decimal total)
    {
        return Balance >= total;
    }
}
