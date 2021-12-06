namespace BancoApp.Domain.Factories;
using BancoApp.Domain.Models;
using BancoApp.Domain.Models.Enums;


public class BankFactory : IBankFactory
{

    static readonly Bank Inter = new Inter(new List<Account> {
                    new Account ("001", 500),
                    new Account ("002", 400),
                });

    static readonly Bank Nubank = new Nubank(new List<Account> {
                    new Account ("001", 300),
                    new Account ("002", 100),
                });

    public Bank Create(BankNumberEnum bankNumber)
    {
        return bankNumber switch
        {
            BankNumberEnum.Nubank => Nubank,
            BankNumberEnum.Inter => Inter,
            _ => throw new Exception("Numero de banco invalido"),
        };
    }
}

