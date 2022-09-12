using FluentAssertions;
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
            TransactionRepository repository = new TransactionRepository();

            // act
            var result = repository.GetAllTransactions();

            // assert
            result.Should().HaveCount(0);
        }
    }
}
