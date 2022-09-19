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
        private Mock<ITransactionRepository> _repository;
        private readonly TransactionSrvc _transactionService;

        public TransactionServiceTest()
        {
            _repository = new Mock<ITransactionRepository>();

            _transactionService = new TransactionSrvc(_repository.Object);

        }

        [Fact]
        public void GivenNoTransaction_ThenReturnEmptyList()
        {
            // arrange 
            _repository.Setup(x => x.GetAllTransactions()).Returns(new List<Transaction>());

            // act
            var result = _transactionService.GetAllTransactions();

            // assert
            result.Should().HaveCount(0);
        }

        [Fact]
        public void GivenATransaction_ThenReturnATransaction()
        {
            // arrange 
            var transaction = AutoFaker.Generate<Transaction>();
            
            _repository.Setup(x => x.GetAllTransactions()).Returns(new List<Transaction>() { transaction });

            // act
            var result = _transactionService.GetAllTransactions();

            // assert
            result.Should().HaveCount(1);
        }

        [Fact]
        public void GivenATransaction_WhenAddTransaction_ThenRegisterInRepository()
        {
            // arrange 
            var transaction = AutoFaker.Generate<Transaction>();
            _repository.Setup(x => x.GetAllTransactions()).Returns(new List<Transaction>() { transaction });

            // act
            _transactionService.AddTransaction(transaction);
            var result = _transactionService.GetAllTransactions();

            // assert
            result.Should().HaveCount(1);
        }
    }
}
