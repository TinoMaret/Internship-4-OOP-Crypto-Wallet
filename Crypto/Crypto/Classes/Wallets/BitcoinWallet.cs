using Crypto.Classes.Assets;
using Crypto.Interfaces;

namespace Crypto.Classes.Wallets
{
    public class BitcoinWallet: Wallet, IFungibleAssetTransaction
    {
        public BitcoinWallet() : base() {
            ListOfSupportedAssets = new List<Guid> {
                ListsOfValidAssets.ListOfFungibleAssets[3].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[4].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[5].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[6].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[7].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[8].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[9].AdressOfAsset,
            };

            ValletType = "BTC";
        }

        public override double CalculateValueOfAllAssetsInUSD()
        {
            return base.CalculateValueOfAllAssetsInUSD();
        }
    }
}
