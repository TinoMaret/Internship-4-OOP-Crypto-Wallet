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

        public static Wallet GetWalletByAdress(Guid AdressOfSearchedWallet) {
            Wallet NewWallet = null;
            foreach (var wal in AllWallets) {
                if (wal.AdressOfWallet == AdressOfSearchedWallet) 
                    return wal;
            }
            return NewWallet;
        }

        public static WalletsContainingNonFungable GetWalletContainingNonFungibleByAdress(Guid AdressOfSearchedWallet)
        {
            WalletsContainingNonFungable NewWallet = null;
            foreach (var wal in AllWallets)
            {
                if (wal.AdressOfWallet == AdressOfSearchedWallet) {
                    return (WalletsContainingNonFungable)wal;
                }
            }
            return NewWallet;
        }
    }
}
