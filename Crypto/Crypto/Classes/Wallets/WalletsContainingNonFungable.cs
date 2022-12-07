using Crypto.Classes.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Classes.Wallets
{
    public class WalletsContainingNonFungable:Wallet
    {
        public List<Guid> AdressesOfNonFungibleAssets = new List<Guid>();

        public WalletsContainingNonFungable() : base() { }

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
    }
}
