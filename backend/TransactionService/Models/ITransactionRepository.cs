
namespace TransactionMicroService.Models
{
    public interface ITransactionRepository
    {
        List<Transaction> GetAllTransactions();
        void AddTransaction(Transaction transaction);
    }
}