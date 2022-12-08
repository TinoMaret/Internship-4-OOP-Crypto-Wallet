namespace Crypto.Classes.Transactions
{
    public static class ListOfTransactions
    {
        public static List<Transaction> AllTransactions = new List<Transaction>();

        public static void AddNewTransaction(Transaction NewTransaction) {
            AllTransactions.Add(NewTransaction);
        }

        public static void RemoveTransaction(Transaction TransactionToRemove) {
            AllTransactions.Remove(TransactionToRemove);
        }

        public static bool CheckIfTransactionExists(Guid AdressOfTransactionToRemove) {
            foreach (var transaction in AllTransactions)
            {
                if (transaction.Id == AdressOfTransactionToRemove)
                    return true;
            }
            return false;
        }

        public static Transaction GetTransactionByAdress(Guid AdressOfTransactionToRemove)
        {
            foreach (var transaction in AllTransactions) {
                if(transaction.Id == AdressOfTransactionToRemove)
                    return transaction;
            }
            return null;
        }
    }
}
