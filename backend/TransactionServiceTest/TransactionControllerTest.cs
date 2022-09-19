using AutoBogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using TransactionMicroService.Models;
using TransactionMicroService.Services;
using TransactionService.Controllers;
using Xunit;

namespace TransactionServiceTest;

public class TransactionControllerTest
{

    [Fact]
    public void GivenNoTramsactionRegister_WhenCallGetAll_ThenReturnOk200()
    {
        // arrange

        Mock<ITransactionSrvc> service = new();
        var controller = new TransactionController(service.Object);

        service.Setup(x => x.GetAllTransactions()).Returns(new List<Transaction> { });

        // act 
        var transactions = controller.GetAll();

        // assert
        transactions.Should().NotBeNull();

        var result = transactions.Result as ObjectResult;
        result.StatusCode.Should().Be(200);
        result.Value.Should().NotBeNull();

        var value = result.Value as List<Transaction>;
        value.Should().HaveCount(0);
    }

    [Fact]
    public void GivenARegistredTransaction_WhenCallGetAll_ThenReturnATransaction()
    {
        // arrange
        Transaction transaction = AutoFaker.Generate<Transaction>();
        Mock<ITransactionSrvc> service = new();
        var controller = new TransactionController(service.Object);
        service.Setup(x => x.GetAllTransactions()).Returns(new List<Transaction> { transaction});

        // act 
        var transactions = controller.GetAll();

        // assert
        transactions.Should().NotBeNull();

        var result = transactions.Result as ObjectResult;
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(200);
        result.Value.Should().NotBeNull();

        var value = result.Value as List<Transaction>;
        value.Should().NotBeNull();
        value.Should().HaveCount(1);
        value[0].Should().NotBeNull();
        value[0].Should().Be(transaction);
    }

}