using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crypto.Classes.Assets;

namespace Crypto.Classes.Assets
{
    public class FungibleAsset: Asset
    {
        public string MeasuringUnit { get; private set; }
        public double ValueInUSD { get; private set; }
        public FungibleAsset(string NameOfNewAsset, string MeasuringUnitOfNewAsset, double ValueInUSDOfNewAsset) : base(NameOfNewAsset) {
            MeasuringUnit = MeasuringUnitOfNewAsset;
            ValueInUSD = ValueInUSDOfNewAsset;
        }
    }
}
