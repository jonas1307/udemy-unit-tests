﻿using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnitTests;

namespace UnitTests
{
    public interface ILog
    {
        void Write(string msg);
    }

    public class ConsoleLog : ILog
    {
        public void Write(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    public class BankAccountNew
    {
        public int Balance { get; set; }
        private readonly ILog _log;

        public BankAccountNew(ILog log)
        {
            _log = log;
        }

        public void Deposit(int amount)
        {
            Balance += amount;
        }
    }
}

[TestFixture]
public class BankAccountNewTests
{
    private BankAccountNew ba;

    [Test]
    public void DepositIntegrationTest()
    {
        ba = new BankAccountNew(new ConsoleLog()) { Balance = 100 };
        ba.Deposit(100);

        Assert.That(ba.Balance, Is.EqualTo(200));
    }
}