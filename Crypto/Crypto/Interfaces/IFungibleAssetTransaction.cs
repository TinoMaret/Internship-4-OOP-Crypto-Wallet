using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Interfaces
{
    public interface IFungibleAssetTransaction
    {
        void FungibleTransaction(Guid AdressOfSender, Guid AdressOfReciver, Guid AdressOfAsset, double HowMuch);
    }
}
