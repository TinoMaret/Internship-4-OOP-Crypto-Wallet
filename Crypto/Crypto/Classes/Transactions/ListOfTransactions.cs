using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Classes.Transactions
{
    public static class ListOfTransactions
    {
        public static List<Transaction> AllTransactions = new List<Transaction>();

        public static void AddNewTransaction(Transaction NewTransaction) {
            AllTransactions.Add(NewTransaction);
        }
    }
}
