using BancoApp.Domain.Factories;
using BancoApp.Domain.Models.Enums;
using BancoApp.Domain.Operations;
using BancoApp.Domain.Operations.Statement;
using BancoApp.Domain.Operations.Withdraw;
using BancoApp.Shared.Extensions;

var builder = WebApplication.CreateBuilder();

builder.Services
    .AddSingleton<IBankFactory, BankFactory>()
    .AddSingleton<WithdrawOperation>()
    .AddSingleton<StatementOperation>()
    .AddSingleton<BankOperations>();

var app = builder.Build();

app.MapPost("/banks/{bankNumber}/accounts/{accountNumber}/withdraw", async (context) =>
{
    try
    {
        var bankNumber = context.Request.RouteValues["bankNumber"].ToEnum<BankNumberEnum>().OrThrow("invalid bank number");
        var accountNumber = context.Request.RouteValues["accountNumber"]?.ToString().OrThrow("invalid account number");
        var command = await context.Request.ReadFromJsonAsync<WithdrawCommand>().OrThrow("invalid request body");

        context
            .RequestServices
            .GetService<BankOperations>()
            ?.Withdraw
            .Execute(command! with { AccountNumber = accountNumber!, BankNumber = bankNumber });

        await context.Response.WriteAsJsonAsync(new { Message = $"Saque valor {command?.Amount} realizado com sucesso" });
        context.Response.StatusCode = 200;
    }
    catch (Exception ex)
    {
        await context.Response.WriteAsJsonAsync(new { ex.Message });
        context.Response.StatusCode = 500;
    }

});

app.MapGet("/banks/{bankNumber}/accounts/{accountNumber}/statement", async (context) =>
{
    try
    {
        var bankNumber = context.Request.RouteValues["bankNumber"].ToEnum<BankNumberEnum>().OrThrow("invalid bank number");
        var accountNumber = context.Request.RouteValues["accountNumber"]?.ToString().OrThrow("invalid account number");

        var statement = context
            .RequestServices
            .GetService<BankOperations>()
            ?.Statement
            .Execute(new StatementCommand(bankNumber, accountNumber!));

        await context.Response.WriteAsJsonAsync(new { Statement = statement });
        context.Response.StatusCode = 200;
    }
    catch (Exception ex)
    {
        await context.Response.WriteAsJsonAsync(new { ex.Message });
        context.Response.StatusCode = 500;
    }

});


app.Run();





