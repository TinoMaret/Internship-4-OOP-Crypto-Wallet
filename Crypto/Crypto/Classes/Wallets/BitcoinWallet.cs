using Crypto.Classes.Assets;
using Crypto.Classes.Transactions;
using Crypto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Classes.Wallets
{
    public class BitcoinWallet: Wallet, IFungibleAssetTransaction
    {
        BitcoinWallet() : base() {
            ListOfSupportedAssets = new List<Guid> {
                ListsOfValidAssets.ListOfFungibleAssets[3].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[4].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[5].AdressOfAsset
            };

            ValletType = "BTC";
        }

        public void FungibleTransaction(Guid AdressOfSender, Guid AdressOfReciver, Guid AdressOfAsset, double HowMuch) {
            if (FungibleAssetTransaction.CheckIfAssetIsFungible(AdressOfAsset)) {
                FungibleAssetTransaction NewTransaction = new FungibleAssetTransaction(AdressOfSender, AdressOfReciver, AdressOfAsset, HowMuch);
                Wallet SendingWallet = ListOfWallets.GetWalletByAdress(AdressOfSender);
                foreach (var FungibleAsset in SendingWallet.FungibleAssetBalance)
                {
                    if (FungibleAsset.Item1 == NewTransaction.AssetAdress)
                    {
                        double temp = FungibleAsset.Item2;
                        SendingWallet.FungibleAssetBalance.Remove(FungibleAsset);
                        SendingWallet.FungibleAssetBalance.Add((NewTransaction.AssetAdress, temp - HowMuch));
                    }
                }
                Wallet RecievingWallet = ListOfWallets.GetWalletByAdress(AdressOfReciver);
                foreach (var FungibleAsset in RecievingWallet.FungibleAssetBalance)
                {
                    if (FungibleAsset.Item1 == NewTransaction.AssetAdress)
                    {
                        double temp = FungibleAsset.Item2;
                        RecievingWallet.FungibleAssetBalance.Remove(FungibleAsset);
                        RecievingWallet.FungibleAssetBalance.Add((NewTransaction.AssetAdress, temp - HowMuch));
                    }
                }
                ListOfTransactions.AddNewTransaction(NewTransaction);
            }
        }

        public override double CalculateValueOfAllAssetsInUSD()
        {
            return base.CalculateValueOfAllAssetsInUSD();
        }
    }
}
