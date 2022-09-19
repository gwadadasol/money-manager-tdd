using AutoBogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionMicroService.Models;
using TransactionMicroService.Services;
using TransactionService.Controllers;
using Xunit;

namespace TransactionServiceTest
{
    public class Features
    {
        private readonly TransactionController _controller;

        public Features()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
    .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var dbContext = new AppDbContext(optionsBuilder.Options);

            TransactionRepository repository = new TransactionRepository(dbContext);
            TransactionSrvc service = new TransactionSrvc(repository);
            _controller = new TransactionController(service);

        }
        [Fact]
        public void GivenASetofTransactionRegistered_WhenCallGetAllTransactions_ThenRetrieveAllTransactions()
        {
            // arrange
            Transaction transaction1 = AutoFaker.Generate<Transaction>();
            Transaction transaction2 = AutoFaker.Generate<Transaction>();

            _controller.Post(transaction1);
            _controller.Post(transaction2);

            // act
            var transactions = _controller.GetAll() ;

            // assert
            transactions.Should().NotBeNull();

            var result = transactions.Result as OkObjectResult;
            result.Should().NotBeNull(); 
            result.StatusCode.Should().Be(200);
            result.Value.Should().NotBeNull();

            var value = result.Value as List<Transaction>;
            value.Should().NotBeNull(); 
            value.Should().HaveCount(2);
            value[0].Should().NotBeNull();
            value[1].Should().NotBeNull();
            value[0].Should().Be(transaction1);
            value[1].Should().Be(transaction2);
        }

        [Fact]
        public void GivenNoTransactionRegistered_WhenCallGetAllTransactions_ThenRetrieveNoTransaction()
        {
            //arrange 

            // act
            var transactions = _controller.GetAll();

            // assert
            transactions.Should().NotBeNull();

            var result = transactions.Result as OkObjectResult;
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
            result.Value.Should().NotBeNull();

            var value = result.Value as List<Transaction>;
            value.Should().NotBeNull();
            value.Should().HaveCount(0);
        }
        [Fact]
        public void GivenException_WhenCallGetAllTransactions_ThenReturnErrorBadRequest()
        {
            // arrange
            Mock<ITransactionSrvc> service = new Mock<ITransactionSrvc>();
            service.Setup(f => f.GetAllTransactions()).Throws(new Exception());
            TransactionController controller = new TransactionController(service.Object);

            // act
            var transactions = controller.GetAll();

            // assert
            transactions.Should().NotBeNull();

            var result = transactions.Result as ObjectResult;
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(400);
        }


    }
}
