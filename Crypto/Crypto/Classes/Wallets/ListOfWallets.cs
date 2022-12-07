using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Classes.Wallets
{
    public static class ListOfWallets
    {
        public static List<Wallet> AllWallets = new List<Wallet>();

        public static void AddNewWallet(Wallet NewWallet) {
            AllWallets.Add(NewWallet);
        }
    }
}
