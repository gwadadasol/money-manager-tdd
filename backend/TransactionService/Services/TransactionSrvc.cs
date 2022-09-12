

using TransactionMicroService.Models;

namespace TransactionMicroService.Services
{
    public class TransactionSrvc : ITransactionSrvc
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionSrvc(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public List<Transaction> GetAllTransactions()
        {
            return _transactionRepository.GetAllTransactions();
        }

        public void AddTransaction(Transaction transaction)
        {
            _transactionRepository.AddTransaction(transaction);
        }
    }
}
