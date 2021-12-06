using BancoApp.Domain.Models.Enums;

namespace BancoApp.Domain.Operations.Statement;

public record StatementCommand(BankNumberEnum BankNumber, string AccountNumber);
