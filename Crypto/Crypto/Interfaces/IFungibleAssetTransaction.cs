namespace Crypto.Interfaces
{
    public interface IFungibleAssetTransaction
    {
        void FungibleTransaction(Guid AdressOfSender, Guid AdressOfReciver, Guid AdressOfAsset, double HowMuch);
    }
}
