using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionMicroService.Models;
using Xunit;

namespace TransactionServiceTest
{
    public class TransactionRepositoryTest
    {
        [Fact]
        public void GivenNoTransaction_ThenReturnEmpty()
        {
            // arrange

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var dbContext = new AppDbContext(optionsBuilder.Options);

            TransactionRepository repository = new TransactionRepository(dbContext);

            // act
            var result = repository.GetAllTransactions();

            // assert
            result.Should().HaveCount(0);
        }
    }
}
