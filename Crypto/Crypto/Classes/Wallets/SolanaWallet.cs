using Crypto.Classes.Assets;

namespace Crypto.Classes.Wallets
{
    public class SolanaWallet : WalletsContainingNonFungable
    {
        public SolanaWallet() : base(){
            ListOfSupportedAssets = new List<Guid> {
                ListsOfValidAssets.ListOfFungibleAssets[4].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[5].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[6].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[7].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[8].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[9].AdressOfAsset,
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
                ListsOfValidAssets.ListOfNonFungibleAssets[15].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[16].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[17].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[18].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[19].AdressOfAsset
            };
            ValletType = "SOL";
        }
    }
}
