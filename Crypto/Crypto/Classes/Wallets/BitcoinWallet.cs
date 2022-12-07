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
        public BitcoinWallet() : base() {
            ListOfSupportedAssets = new List<Guid> {
                ListsOfValidAssets.ListOfFungibleAssets[3].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[4].AdressOfAsset,
                ListsOfValidAssets.ListOfFungibleAssets[5].AdressOfAsset
            };

            ValletType = "BTC";
        }

        public override double CalculateValueOfAllAssetsInUSD()
        {
            return base.CalculateValueOfAllAssetsInUSD();
        }
    }
}
