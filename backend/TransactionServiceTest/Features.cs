using FluentAssertions;
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
        [Fact]
        public void GivenASetofTransactionPost_WhenCallGetAll_ThenRetriveAllTransactions()
        {
            TransactionRepository repository = new TransactionRepository();
            TransactionSrvc service = new TransactionSrvc(repository);
            TransactionController controller = new TransactionController(service);
            Transaction transaction1 = new() { Amount = 1};
            Transaction transaction2 = new() { Amount = 2};

            controller.Post(transaction1 );
            controller.Post(transaction2);

            var transactions = controller.GetAll();

            transactions.Value.Should().NotBeNull();
            transactions.Value.Should().HaveCount(2);
            transactions.Value[0].Should().NotBeNull();
            transactions.Value[1].Should().NotBeNull();
            transactions.Value[0].Should().Be(transaction1);
            transactions.Value[1].Should().Be(transaction2);


        }
    }
}
