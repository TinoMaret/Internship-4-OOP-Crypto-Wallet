using Crypto.Classes.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Classes.Wallets
{
    public class EthereumWallet: WalletsContainingNonFungable
    {
        public EthereumWallet() : base() {
            ListOfSupportedAssets = new List<Guid> {
                ListsOfValidAssets.ListOfFungibleAssets[0].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[1].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[4].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[1].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[2].AdressOfAsset,
                ListsOfValidAssets.ListOfNonFungibleAssets[4].AdressOfAsset
            };

            ValletType = "ETH";
        }
    }
}
