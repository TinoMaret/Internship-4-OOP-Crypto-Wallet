﻿using Crypto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Classes.Transactions
{
    public abstract class Transaction
    {
        public Guid Id { get; private set; }
        public DateTime TimeOfTransaction { get; private set; }
        public Guid SendingAdress { get; private set; }
        public Guid RecievingAdress { get; private set; }
        public Guid AssetAdress { get; private set; }
        public bool IsRevoked { get; private set; }

        public Transaction(Guid AdressOfSender, Guid AdressOfReciver, Guid AdressOfAsset)
        {
            Id = Guid.NewGuid();
            TimeOfTransaction = DateTime.Now;
            SendingAdress = AdressOfSender;
            RecievingAdress = AdressOfReciver;
            AssetAdress = AdressOfAsset;
            IsRevoked = false;
        }
    }
}
