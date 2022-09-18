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
    public void GivenNoError_WhenCallGetAll_ThenReturnOk200()
    {
        // arrange

        Mock<ITransactionSrvc> service = new();
        var controller = new TransactionController(service.Object);

        service.Setup(x => x.GetAllTransactions()).Returns(new List<Transaction> { });

        // act 
        var result = controller.GetAll();

        // assert
        result.Value.Should().BeOfType(typeof(List<Transaction>));
    }

    //public void GivenARegistredTransaction_WhenCallGetAll_ThenReturnATransaction()
    //{
    //    // arrange

    //    // act 

    //    // assert
    //}

}