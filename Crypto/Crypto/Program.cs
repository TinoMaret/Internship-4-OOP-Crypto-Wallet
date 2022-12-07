using Crypto.Classes.Assets;
using System;

namespace Crypto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<FungibleAsset> InitialFungibleAssets = new List<FungibleAsset> {
                new FungibleAsset("Nafta", "l", 0.50),
                new FungibleAsset("Drvo", "m^3", 7),
                new FungibleAsset("Benzin", "l", 1),
                new FungibleAsset("Bitcoin", "BTC", 17031),
                new FungibleAsset("Etherium", "ETH", 1222),
                new FungibleAsset("Solana", "SOL", 14.06)
            };

            List<NonFungibleAsset>  InitialNonFungibleAssets = new List<NonFungibleAsset> {
                new NonFungibleAsset("Kuća 1", 100, InitialFungibleAssets[3].AdressOfAsset), 
                new NonFungibleAsset("Kuća 2", 98, InitialFungibleAssets[4].AdressOfAsset),
                new NonFungibleAsset("Kuća 3", 56, InitialFungibleAssets[3].AdressOfAsset),
                new NonFungibleAsset("Painting 1", 7, InitialFungibleAssets[5].AdressOfAsset),
                new NonFungibleAsset("Painting 2", 5, InitialFungibleAssets[3].AdressOfAsset)
            };
        }
    }
}