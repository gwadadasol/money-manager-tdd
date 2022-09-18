using AutoBogus;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
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

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var dbContext = new AppDbContext(optionsBuilder.Options);

            TransactionRepository repository = new TransactionRepository(dbContext);
            TransactionSrvc service = new TransactionSrvc(repository);
            TransactionController controller = new TransactionController(service);
            Transaction transaction1 = AutoFaker.Generate<Transaction>();
            Transaction transaction2 = AutoFaker.Generate<Transaction>();

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
