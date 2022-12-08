using Crypto.Classes.Assets;

namespace Crypto.Classes.Transactions
{
    public class NonFungibleAssetTransaction:Transaction
    {
        public NonFungibleAssetTransaction(Guid AdressOfSender, Guid AdressOfReciver, Guid AdressOfAsset) : base(AdressOfSender, AdressOfReciver, AdressOfReciver) { }





        public override string ToString()
        {
            return base.ToString() + $"Non fungible asset ime - {ListsOfValidAssets.GetExchangedAssetName(AssetAdress)}\n" +
                $"Opozvana - {IsRevoked}";
        }

    }
}
