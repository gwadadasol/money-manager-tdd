using TransactionMicroService.Models;

namespace TransactionMicroService.Services
{
    public interface ITransactionSrvc
    {
        void AddTransaction(Transaction transaction);
        List<Transaction> GetAllTransactions();
    }
}