using System;
using Xunit;
using FluentAssertions;

namespace UnitTestFluentAssertion
{
    public class BankAccountTests
    {
        [Fact]
        public void Credit_PositiveAmountAsParameter_BalanceEquals200()
        {
            //Arrange
            var balance = 100;
            var amount = 100;

            var sut = new BankAccount(balance);

            //Act
            sut.Credit(amount);

            //Assert
            sut.Balance.Should().Be(200);
        }

        [Fact]
        public void Credit_PositiveAmountAsParameter_BalanceTypeIsDouble()
        {
            //Arrange
            var balance = 100;
            var amount = 100;

            var sut = new BankAccount(balance);

            //Act
            sut.Credit(amount);

            //Assert
            sut.Balance.Should().BeOfType(typeof(double));
        }

        [Fact]
        public void Credit_NegativeAmountAsParameter_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            var balance = 100;
            var amount = -1;

            var sut = new BankAccount(balance);

            //Act
            Action action = () => sut.Credit(amount);

            //Assert
            action
                .Should()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Debit_AccountIsFrozen_ThrowsExceptionWithMessage()
        {
            //Arrange
            var balance = 100;
            var amount = 1000;

            var sut = new BankAccount(balance);

            //Act
            sut.FreezeAccount();
            Action action = () => sut.Debit(amount);

            //Assert
            action
                .Should()
                .Throw<Exception>()
                .WithMessage("Account frozen");
        }

        [Fact]
        public void Debit_PositiveAmountAsParameter_NotThrowException()
        {
            //Arrange
            var balance = 100;
            var amount = 50;

            var sut = new BankAccount(balance);

            //Act            
            Action action = () => sut.Debit(amount);

            //Assert
            action
                .Should()
                .NotThrow<Exception>();
        }
    }
}
