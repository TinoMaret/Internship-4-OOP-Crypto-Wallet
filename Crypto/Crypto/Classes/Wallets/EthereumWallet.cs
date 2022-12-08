using Crypto.Classes.Assets;

namespace Crypto.Classes.Wallets
{
    public class EthereumWallet: WalletsContainingNonFungable
    {
        public EthereumWallet() : base() {
            ListOfSupportedAssets = new List<Guid> {
                ListsOfValidAssets.ListOfFungibleAssets[0].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[1].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[2].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[3].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[4].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[5].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[6].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[7].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[0].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[1].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[2].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[3].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[4].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[5].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[6].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[7].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[8].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[9].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[10].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[11].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[12].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[13].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[14].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[15].AdressOfAsset
            };
            ValletType = "ETH";
        }
    }
}
