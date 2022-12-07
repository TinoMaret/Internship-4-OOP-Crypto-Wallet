using Crypto.Classes.Assets;
using Crypto.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crypto.Interfaces;
using Crypto.Classes.Transactions;

namespace Crypto.Classes.Wallets
{
    public class Wallet: IFungibleAssetTransaction
    {
        public Guid AdressOfWallet { get; }
        public List<(Guid, double)> FungibleAssetBalance { get; private set; } = new List<(Guid, double)>();
        public List<Guid> ListOfSupportedAssets { get; set; } = new List<Guid>();
        public List<Guid> AdressesOfTransactions { get; private set; } = new List<Guid>();
        public string ValletType { get; set; } = "";
        protected double ValueOfAllAssetsInUSD { get; set; }
        public double PercentChange { get; set; } = 0;
        public double LastShown { get; set; } = 0;
        public Wallet() {
            AdressOfWallet = Guid.NewGuid();
            ValueOfAllAssetsInUSD = 0;
            PercentChange = 0;
        }

        public string ChangeSinceLastShown() {
            double temp = LastShown;
            LastShown = ValueOfAllAssetsInUSD;
            return (temp/ValueOfAllAssetsInUSD).ToString();
        }

        public virtual double CalculateValueOfAllAssetsInUSD() {
            double CalculatedValueOfAllAssetsInUSD = 0;
            foreach (var asset in FungibleAssetBalance)
            {
            CalculatedValueOfAllAssetsInUSD += asset.Item2 * ValueInUSDOfFungibleAssetInWallet(asset);
            }
            return CalculatedValueOfAllAssetsInUSD;
        }

        public double ValueInUSDOfFungibleAssetInWallet((Guid, double) FungibleAssetBalanceToFindValue) {
            double FoundValue = 0;
            foreach (var asset in ListsOfValidAssets.ListOfFungibleAssets) {
                if (asset.AdressOfAsset == FungibleAssetBalanceToFindValue.Item1) { 
                    FoundValue = asset.ValueInUSD;
                    continue;
                }
            }
            return FoundValue;
        }

        public void AddAdressOfTransaction(Guid PassedAdressOfTransaction) {
            AdressesOfTransactions.Add(PassedAdressOfTransaction);
        }

        public void FungibleTransaction(Guid AdressOfSender, Guid AdressOfReciver, Guid AdressOfAsset, double HowMuch)
        {
            if (FungibleAssetTransaction.CheckIfAssetIsSupported(AdressOfAsset, AdressOfReciver))
            {
                FungibleAssetTransaction NewTransaction = new FungibleAssetTransaction(AdressOfSender, AdressOfReciver, AdressOfAsset, HowMuch);
                Wallet SendingWallet = ListOfWallets.GetWalletByAdress(AdressOfSender);
                foreach (var fungibleAsset in SendingWallet.FungibleAssetBalance)
                {
                    if (fungibleAsset.Item1 == NewTransaction.AssetAdress)
                    {
                        double temp = fungibleAsset.Item2;
                        SendingWallet.FungibleAssetBalance.Remove(fungibleAsset);
                        SendingWallet.FungibleAssetBalance.Add((NewTransaction.AssetAdress, NewTransaction.FungibleAssetValueAfterSending));
                    }
                }
                SendingWallet.AddAdressOfTransaction(NewTransaction.Id);
                Wallet RecievingWallet = ListOfWallets.GetWalletByAdress(AdressOfReciver);
                List<Guid> ListOfOwnedFungibleAssets = new List<Guid>();
                foreach (var fungibleAsset in RecievingWallet.FungibleAssetBalance)
                {
                    ListOfOwnedFungibleAssets.Add(fungibleAsset.Item1);
                }
                if (ListOfOwnedFungibleAssets.Contains(NewTransaction.AssetAdress))
                {
                    foreach (var fungibleAsset in RecievingWallet.FungibleAssetBalance)
                    {
                        if (fungibleAsset.Item1 == AdressOfAsset)
                        {
                            double temp = fungibleAsset.Item2;
                            RecievingWallet.FungibleAssetBalance.Remove(fungibleAsset);
                            RecievingWallet.FungibleAssetBalance.Add((NewTransaction.AssetAdress, NewTransaction.FungibleAssetValueAfterRecieving));
                        }
                    }
                }
                else
                    RecievingWallet.FungibleAssetBalance.Add((NewTransaction.AssetAdress, HowMuch));
                RecievingWallet.AddAdressOfTransaction(NewTransaction.Id);
                ListsOfValidAssets.ChangeValueOfAnAsset(AdressOfAsset);
                ListOfTransactions.AddNewTransaction(NewTransaction);
            }
            else
                Console.WriteLine("Ne mogu izvrsiti transakciju(Wallet ne podrzava asset)");
        }

        public void AllDoneTransactions() {
            List<Transaction> ListOfDoneTransactions = new List<Transaction>();
            foreach (Guid adressOfTransactio in AdressesOfTransactions) {
                foreach (Transaction transaction in ListOfTransactions.AllTransactions) {
                    if (transaction.Id == adressOfTransactio) {
                        ListOfDoneTransactions.Add(transaction);
                    }
                }
            }
            foreach (Transaction transaction in ListOfDoneTransactions) {
                Console.WriteLine(transaction.ToString());
            }
        }

        public override string ToString()
        {
            return $"Tip Walleta - {ValletType} \n" +
                $"Adressa Walleta - {AdressOfWallet} \n" +
                $"Ukupna vrijednost svih asseta u USD {CalculateValueOfAllAssetsInUSD()} \n" +
                $"Postotak pada/povecanja {ChangeSinceLastShown()}"; 
        }

        public void Portfolio() {
            Console.WriteLine( $"Ukupna vrijednost svih asseta - { CalculateValueOfAllAssetsInUSD()}");
            int brojac = 0;
            List<FungibleAsset> ListOfOwnedFungibleAssets = new List<FungibleAsset>();
            foreach (var fungibleAssetInWallet in FungibleAssetBalance) {
                foreach (var fungibleAsset in ListsOfValidAssets.ListOfFungibleAssets)
                {
                    if(fungibleAssetInWallet.Item1 == fungibleAsset.AdressOfAsset)
                    ListOfOwnedFungibleAssets.Add(fungibleAsset);
                }
            }
            foreach (var OwnedFungibleAsset in ListOfOwnedFungibleAssets) {
                Console.WriteLine(OwnedFungibleAsset.AdressOfAsset);
                Console.WriteLine(OwnedFungibleAsset.Name);
                Console.WriteLine(OwnedFungibleAsset.MeasuringUnit);
                Console.WriteLine(OwnedFungibleAsset.ShowChangeSinceLastSeen());
            }
        }
    }
}
