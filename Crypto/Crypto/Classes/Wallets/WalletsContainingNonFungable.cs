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
    public abstract class WalletsContainingNonFungable : Wallet, IFungibleAssetTransaction, INonFungibleAssetTransaction
    {
        public List<Guid> AdressesOfNonFungibleAssets { get; set; }

        public WalletsContainingNonFungable() : base()
        {
            AdressesOfNonFungibleAssets = new List<Guid>();
        }

        public override double CalculateValueOfAllAssetsInUSD()
        {
            return base.CalculateValueOfAllAssetsInUSD() + CalculateValueOfAllNonFungibleAssetsInWallet();
        }

        public double CalculateValueOfAllNonFungibleAssetsInWallet()
        {
            double SumOfValues = 0;
            foreach (var asset in AdressesOfNonFungibleAssets)
            {
                SumOfValues += ValueOfNonFungibleAssetInWallet(asset);
            }
            return SumOfValues;
        }

        public double ValueOfNonFungibleAssetInWallet(Guid AdressOfNonFungibleAssetToFindValue)
        {
            var ReferenceAdressOfNonFungableAsset = Guid.Empty;
            double ValueOfNonFungibleAsset = 0;
            double USDValueOfPassedNonFungableAsset = 0;
            foreach (var asset in ListsOfValidAssets.ListOfNonFungibleAssets)
            {
                if (asset.AdressOfAsset == AdressOfNonFungibleAssetToFindValue)
                {
                    ReferenceAdressOfNonFungableAsset = asset.AdressOfFungibleItemForValue;
                    ValueOfNonFungibleAsset = asset.Value;
                    break;
                }
            }
            foreach (var asset in ListsOfValidAssets.ListOfFungibleAssets)
            {
                if (asset.AdressOfAsset == ReferenceAdressOfNonFungableAsset)
                {
                    USDValueOfPassedNonFungableAsset = ValueOfNonFungibleAsset * asset.ValueInUSD;
                    break;
                }
            }
            return USDValueOfPassedNonFungableAsset;
        }

        public void NonFungibleTransaction(Guid AdressOfSender, Guid AdressOfReciver, Guid AdressOfAsset)
        {
            if (NonFungibleAssetTransaction.CheckIfAssetIsNonFungible(AdressOfAsset))
            {
                NonFungibleAssetTransaction NewTransaction = new NonFungibleAssetTransaction(AdressOfSender, AdressOfReciver, AdressOfAsset);
                WalletsContainingNonFungable SendingWallet = ListOfWallets.GetWalletContainingNonFungibleByAdress(AdressOfSender);
                foreach (var NonFungibleAsset in SendingWallet.AdressesOfNonFungibleAssets)
                {
                    if (NonFungibleAsset == AdressOfAsset)
                    {
                        SendingWallet.AdressesOfNonFungibleAssets.Remove(NonFungibleAsset);
                    }
                }
                WalletsContainingNonFungable RecievingWallet = ListOfWallets.GetWalletContainingNonFungibleByAdress(AdressOfReciver);
                RecievingWallet.AdressesOfNonFungibleAssets.Add(AdressOfAsset);
            }
        }

        public void FungibleTransaction(Guid AdressOfSender, Guid AdressOfReciver, Guid AdressOfAsset, double HowMuch)
        {
            if (FungibleAssetTransaction.CheckIfAssetIsFungible(AdressOfAsset))
            {
                FungibleAssetTransaction NewTransaction = new FungibleAssetTransaction(AdressOfSender, AdressOfReciver, AdressOfAsset, HowMuch);
                Wallet SendingWallet = ListOfWallets.GetWalletByAdress(AdressOfSender);
                foreach (var fungibleAsset in SendingWallet.FungibleAssetBalance)
                {
                    if (fungibleAsset.Item1 == NewTransaction.AssetAdress)
                    {
                        double temp = fungibleAsset.Item2;
                        SendingWallet.FungibleAssetBalance.Remove(fungibleAsset);
                        SendingWallet.FungibleAssetBalance.Add((NewTransaction.AssetAdress, temp - HowMuch));
                    }
                }
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
                            RecievingWallet.FungibleAssetBalance.Add((NewTransaction.AssetAdress, temp + HowMuch));
                        }
                    }
                }
                else
                    RecievingWallet.FungibleAssetBalance.Add((NewTransaction.AssetAdress, HowMuch));

                ListOfTransactions.AddNewTransaction(NewTransaction);
            }
        }
    }
}
