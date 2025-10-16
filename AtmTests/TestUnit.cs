using System;
using Xunit;

namespace AtmTests;

public class Atm
{
    public decimal Balance { get; private set; }

    public Atm(decimal initialBalance)
    {
        if (initialBalance < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(initialBalance), "Initial balance cannot be negative.");
        }

        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positive.");
        }

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive.");
        }

        if (amount > Balance)
        {
            throw new InvalidOperationException("Cannot withdraw more than the available balance.");
        }

        Balance -= amount;
    }
}

public class AtmTests
{
    [Fact]
    public void TestUnit()
    {
        var atm = new Atm(100m);

        atm.Deposit(50m);
        atm.Withdraw(30m);

        Assert.Equal(120m, atm.Balance);
    }
}
