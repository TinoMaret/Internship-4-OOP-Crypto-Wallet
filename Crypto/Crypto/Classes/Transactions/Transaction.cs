using Crypto.Classes.Wallets;

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

        public static bool CheckIfAssetIsSupported(Guid AdressOfSentAsset, Guid AdressOfRecieveingWallet)
        {
            foreach (var wal in ListOfWallets.AllWallets)
            {
                if (wal.AdressOfWallet == AdressOfRecieveingWallet)
                    if (wal.ListOfSupportedAssets.Contains(AdressOfSentAsset))
                        return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Id Transakcije - {Id}\n" +
                $"Datum i vrijeme transakcije {TimeOfTransaction}\n" +
                $"Adressa walleta koji salje {SendingAdress}\n" +
                $"Adressa walleta koji prima {RecievingAdress}\n";
        }
    }
}
