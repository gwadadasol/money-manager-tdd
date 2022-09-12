using AutoBogus;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using TransactionMicroService.Models;
using TransactionMicroService.Services;
using Xunit;

namespace TransactionServiceTest
{
    public class TransactionServiceTest
    {
        [Fact]
        public void GivenNoTransaction_ThenReturnEmptyList()
        {
            // arrange 
            Mock<ITransactionRepository> repository = new Mock<ITransactionRepository>();

            TransactionSrvc transactionService = new TransactionSrvc(repository.Object);

            repository.Setup(x => x.GetAllTransactions()).Returns(new List<Transaction>());


            // act
            var result = transactionService.GetAllTransactions();

            // assert
            result.Should().HaveCount(0);
        }

        [Fact]
        public void GivenATransaction_ThenReturnATransaction()
        {
            // arrange 
            var transaction = AutoFaker.Generate<Transaction>();
            
            Mock<ITransactionRepository> repository = new Mock<ITransactionRepository>();
            repository.Setup(x => x.GetAllTransactions()).Returns(new List<Transaction>() { transaction });

            TransactionSrvc transactionService = new TransactionSrvc(repository.Object);

            // act
            var result = transactionService.GetAllTransactions();

            // assert
            result.Should().HaveCount(1);
        }

        [Fact]
        public void GivenATransaction_WhenAddTransaction_ThenRegisterInRepository()
        {
            // arrange 
            var transaction = AutoFaker.Generate<Transaction>();

            Mock<ITransactionRepository> repository = new Mock<ITransactionRepository>();
            repository.Setup(x => x.GetAllTransactions()).Returns(new List<Transaction>() { transaction });

            TransactionSrvc transactionService = new TransactionSrvc(repository.Object);

            // act
            transactionService.AddTransaction(transaction);
            var result = transactionService.GetAllTransactions();

            // assert
            result.Should().HaveCount(1);
        }
    }
}
