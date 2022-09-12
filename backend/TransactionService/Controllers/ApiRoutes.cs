namespace TransactionService.Controllers
{
    internal class ApiRoutes
    {
        public static class Transaction
        {
            public const string Root = "api";
            public const string Version = "v1";
            public const string Base = Root + "/" + Version;

            public const string GetAll = Base + "/transactions";
            public const string Create = Base + "/transactions";
        }
    }
}