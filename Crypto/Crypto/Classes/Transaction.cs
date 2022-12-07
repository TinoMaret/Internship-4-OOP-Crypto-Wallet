using Crypto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Classes
{
    public class Transaction
    {
        public Guid Id { get; private set; }
        public DateTime TimeOfTransaction { get; private set; }
        public Guid SendingAdress { get; private set; }
        public Guid RecievingAdress { get; private set; }
        public bool IsRevoked { get; private set; }
        public List<Transaction> transactions { get; } = new List<Transaction>();

        public Transaction(Guid AddresOfSender, Guid AdressOfReciver, Guid AdressOfAsset) {
            Id = Guid.NewGuid();
            TimeOfTransaction = DateTime.Now;
            SendingAdress = AddresOfSender;
            RecievingAdress = AdressOfReciver;
        }
    }
}
