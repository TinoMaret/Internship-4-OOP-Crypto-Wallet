﻿using Crypto.Classes.Assets;
using Crypto.Classes.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Classes.Transactions
{
    public class FungibleAssetTransaction:Transaction
    {
        public double FungibleAssetValueBeforeSending { get; set; }
        public double FungibleAssetValueAfterSending { get; set; }
        public double FungibleAssetValueBeforeRecieving { get; set; }
        public double FungibleAssetValueAfterRecieving { get; set; }
        public FungibleAssetTransaction(Guid AdressOfSender, Guid AdressOfReciver, Guid AdressOfAsset, double HowMuch) : base(AdressOfSender, AdressOfReciver, AdressOfReciver) {
            FungibleAssetValueBeforeSending = GetFungibleAssetValueBeforeSending(AdressOfSender, AdressOfAsset);
            FungibleAssetValueAfterSending = GetFungibleAssetValueBeforeSending(AdressOfSender, AdressOfReciver) - HowMuch;
            FungibleAssetValueBeforeRecieving = GetFungibleAssetValueBeforeRecieving(AdressOfReciver, AdressOfAsset);
            FungibleAssetValueAfterRecieving = GetFungibleAssetValueBeforeRecieving(AdressOfReciver, AdressOfAsset) + HowMuch;

        }

        public static bool CheckIfAssetIsFungible(Guid AdressOfSentAsset) {
            foreach (var asset in ListsOfValidAssets.ListOfFungibleAssets) {
                if(asset.AdressOfAsset == AdressOfSentAsset)
                    return true;
            }
            return false;
        }

        public double GetFungibleAssetValueBeforeSending(Guid AdressOfSender, Guid AdressOfAsset)
        {
            double Value = 0;
            foreach (var wal in ListOfWallets.AllWallets) {
                if (wal.AdressOfWallet == AdressOfSender) {
                    foreach (var balance in wal.FungibleAssetBalance) {
                        if (balance.Item1 == AdressOfAsset)
                            Value = balance.Item2;
                    }
                }    
            }
            return Value;
        }

        public double GetFungibleAssetValueBeforeRecieving(Guid AdressOfReciever, Guid AdressOfAsset) {
            double Value = 0;
            foreach (var wal in ListOfWallets.AllWallets)
            {
                if (wal.AdressOfWallet == AdressOfReciever)
                {
                    foreach (var balance in wal.FungibleAssetBalance)
                    {
                        if (balance.Item1 == AdressOfAsset)
                            Value = balance.Item2;
                    }
                }
            }
            return Value;
        }
    }
}