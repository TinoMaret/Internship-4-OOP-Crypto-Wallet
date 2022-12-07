using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Classes.Assets
{
    public class NonFungibleAsset: Asset
    {
        public double Value { get; set; }
        public Guid AdressOfFungibleItemForValue;
        public NonFungibleAsset(string NameOfNewAsset, double ValueOfNewAsset, Guid AdressOfFungibleItemForValueOfNewAsset): base(NameOfNewAsset)
        { 
            Value = ValueOfNewAsset;
            AdressOfFungibleItemForValue = AdressOfFungibleItemForValueOfNewAsset;
        }
    }
}
