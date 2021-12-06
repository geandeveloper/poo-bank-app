using BancoApp.Domain.Models.Enums;

namespace BancoApp.Domain.Models
{
    public class Inter : Bank
    {
        protected override decimal Tax => 0;

        public Inter(IEnumerable<Account> contas) : base(BankNumberEnum.Inter, contas)
        {
        }
    }
}
