namespace TransactionMicroService.Models
{
    public class TransactionRepository : ITransactionRepository
    {
        //private readonly List<Transaction> _transactions;
        private readonly AppDbContext _dbContext;

        //public TransactionRepository()
        //{
        //    _transactions = new List<Transaction>();
        //}
        public TransactionRepository(AppDbContext context)
        {
            _dbContext = context?? throw new ArgumentNullException(nameof(context));
        }
        public void AddTransaction(Transaction transaction)
        {
            //_transactions.Add(transaction);
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
        }

        public List<Transaction> GetAllTransactions()
        {
            //return _transactions;
            return _dbContext.Transactions.ToList();
        }
    }
}
