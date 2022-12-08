namespace Crypto.Classes.Wallets
{
    public static class ListOfWallets
    {
        public static List<Wallet> AllWallets = new List<Wallet>{
            new SolanaWallet(),
            new SolanaWallet(),
            new SolanaWallet(),
            new BitcoinWallet(),
            new BitcoinWallet(),
            new BitcoinWallet(),
            new EthereumWallet(),
            new EthereumWallet(),
            new EthereumWallet(),
        };

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

        public static void Disp() {
            foreach (var wal in AllWallets) {
                Console.WriteLine(wal.ToString());
            }
        }

        public static bool CheckingIfWalletExists(string PassedAdress)
        {
            foreach (var wal in AllWallets) {
                if (wal.AdressOfWallet.ToString() == PassedAdress)
                    return true;
            }
            return false;
        }
    }
}
