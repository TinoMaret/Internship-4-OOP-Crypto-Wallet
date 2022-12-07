using Crypto.Classes.Assets;

namespace Crypto.Classes.Wallets
{
    public class SolanaWallet : WalletsContainingNonFungable
    {
        public SolanaWallet() : base(){
            ListOfSupportedAssets = new List<Guid> {
                ListsOfValidAssets.ListOfFungibleAssets[0].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[3].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[4].AdressOfAsset
            };
            ValletType = "SOL";
        }
    }
}
