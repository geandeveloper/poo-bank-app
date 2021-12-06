using BancoApp.Domain.Models;
using BancoApp.Domain.Models.Enums;

namespace BancoApp.Domain.Factories;

public interface IBankFactory
{
    public Bank Create(BankNumberEnum bankNumber);
}

