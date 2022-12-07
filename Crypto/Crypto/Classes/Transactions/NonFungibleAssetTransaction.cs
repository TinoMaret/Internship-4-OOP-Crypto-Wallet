using Crypto.Classes.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Classes.Transactions
{
    public class NonFungibleAssetTransaction:Transaction
    {
        public NonFungibleAssetTransaction(Guid AdressOfSender, Guid AdressOfReciver, Guid AdressOfAsset) : base(AdressOfSender, AdressOfReciver, AdressOfReciver) { }

        public static bool CheckIfAssetIsNonFungible(Guid AdressOfSentAsset)
        {
            foreach (var asset in ListsOfValidAssets.ListOfNonFungibleAssets)
            {
                if (asset.AdressOfAsset == AdressOfSentAsset)
                    return true;
            }
            return false;
        }
    }
}
