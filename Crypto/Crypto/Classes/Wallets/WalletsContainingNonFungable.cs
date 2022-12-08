using Crypto.Classes.Assets;
using Crypto.Classes.Transactions;
using Crypto.Interfaces;

namespace Crypto.Classes.Wallets
{
    public class WalletsContainingNonFungable : Wallet, INonFungibleAssetTransaction
    {
        public List<Guid> AdressesOfNonFungibleAssets { get; set; }

        public WalletsContainingNonFungable() : base()
        {
            AdressesOfNonFungibleAssets = new List<Guid>();
        }

        public override string ToString()
        {
            return base.ToString();
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
            if (NonFungibleAssetTransaction.CheckIfAssetIsSupported(AdressOfAsset, AdressOfReciver) && (AdressesOfNonFungibleAssets.Contains(AdressOfAsset)))
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
                SendingWallet.AddAdressOfTransaction(NewTransaction.Id);
                WalletsContainingNonFungable RecievingWallet = ListOfWallets.GetWalletContainingNonFungibleByAdress(AdressOfReciver);
                RecievingWallet.AddAdressOfTransaction(NewTransaction.Id);
                ListsOfValidAssets.ChangeValueOfAnAsset(AdressOfAsset);
                RecievingWallet.AdressesOfNonFungibleAssets.Add(AdressOfAsset);
            }
            Console.WriteLine("Ne mogu izvrsiti transakciju(Wallet ne podrzava asset)");
        }

        
    }
}
