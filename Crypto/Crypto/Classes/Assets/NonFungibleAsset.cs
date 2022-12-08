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
