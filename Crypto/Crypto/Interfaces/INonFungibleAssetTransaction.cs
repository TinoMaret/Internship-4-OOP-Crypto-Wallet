namespace Crypto.Interfaces
{
    public interface INonFungibleAssetTransaction
    {
        void NonFungibleTransaction(Guid AdressOfSender, Guid AdressOfReciver, Guid AdressOfAsset);
    }
}
