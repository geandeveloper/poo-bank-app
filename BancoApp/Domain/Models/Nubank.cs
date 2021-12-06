using BancoApp.Domain.Models.Enums;

namespace BancoApp.Domain.Models
{
    public class Nubank : Bank
    {
        protected override decimal Tax => 5.5M;

        public Nubank(IEnumerable<Account> contas) : base(BankNumberEnum.Nubank, contas)
        {
        }
    }
}
