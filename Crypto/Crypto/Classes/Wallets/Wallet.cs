using Crypto.Classes.Assets;
using Crypto.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Classes.Wallets
{
    public class Wallet
    {
        public Guid AdressOfWallet { get; }
        public List<(Guid, double)> FungibleAssetBalance { get; private set; } = new List<(Guid, double)>();
        protected List<Guid> ListOfSupportedAssets { get; set; } = new List<Guid>();
        public List<Guid> AdressesOfTransactions { get; private set; } = new List<Guid>();
        public string ValletType { get; set; } = "";
        protected double ValueOfAllAssetsInUSD { get; set; }
        public Wallet() {
            AdressOfWallet = Guid.NewGuid();
        }

        public virtual double CalculateValueOfAllAssetsInUSD() {
            double CalculatedValueOfAllAssetsInUSD = 0;
            foreach (var asset in FungibleAssetBalance) {
                CalculatedValueOfAllAssetsInUSD += asset.Item2 * ValueInUSDOfFungibleAssetInWallet(asset);
            }
            if (ValueOfAllAssetsInUSD == 0) {
                ValueOfAllAssetsInUSD = CalculatedValueOfAllAssetsInUSD;
                return 0;
            }
            else {
                double temp = ValueOfAllAssetsInUSD;
                ValueOfAllAssetsInUSD = CalculatedValueOfAllAssetsInUSD;
                return CalculatedValueOfAllAssetsInUSD / temp;
            }
                
        }

        public double ValueInUSDOfFungibleAssetInWallet((Guid, double) FungibleAssetBalanceToFindValue) {
            double FoundValue = 0;
            foreach (var asset in ListsOfValidAssets.ListOfFungibleAssets) {
                if (asset.AdressOfAsset == FungibleAssetBalanceToFindValue.Item1) { 
                    FoundValue = asset.ValueInUSD;
                    continue;
                }
            }
            return FoundValue;
        }
    }
}
