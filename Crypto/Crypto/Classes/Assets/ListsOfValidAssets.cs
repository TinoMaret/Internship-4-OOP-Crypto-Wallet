using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Classes.Assets
{
    public static class ListsOfValidAssets
    {
        public static List<FungibleAsset> ListOfFungibleAssets { get; } = new List<FungibleAsset> {
            new FungibleAsset("Nafta", "l", 0.50),
            new FungibleAsset("Drvo", "m^3", 7),
            new FungibleAsset("Benzin", "l", 1),
            new FungibleAsset("Bitcoin", "BTC", 17031),
            new FungibleAsset("Etherium", "ETH", 1222),
            new FungibleAsset("Solana", "SOL", 14.06)
        };
        public static List<NonFungibleAsset> ListOfNonFungibleAssets { get; } = new List<NonFungibleAsset> {
            new NonFungibleAsset("Kuća 1", 100, ListOfFungibleAssets[3].AdressOfAsset),
            new NonFungibleAsset("Kuća 2", 98, ListOfFungibleAssets[4].AdressOfAsset),
            new NonFungibleAsset("Kuća 3", 56, ListOfFungibleAssets[3].AdressOfAsset),
            new NonFungibleAsset("Slika 1", 7, ListOfFungibleAssets[5].AdressOfAsset),
            new NonFungibleAsset("SLika 2", 5, ListOfFungibleAssets[3].AdressOfAsset)
        };


        //Checking if name of a fungible asset is unique and if it is adding it to the list of valid fungible assets
        public static (bool, bool) CheckIfUniqueFungibleAsset(string NameOfNewAsset, string MeasuringUnitOfNewAsset)
        {
            var isFound = (false, false);

            foreach (FungibleAsset fungibleAsset in ListOfFungibleAssets)
            {
                if (!(fungibleAsset.Name == NameOfNewAsset) && !(fungibleAsset.MeasuringUnit == MeasuringUnitOfNewAsset))
                    continue;

                isFound = (fungibleAsset.Name == NameOfNewAsset, fungibleAsset.MeasuringUnit == MeasuringUnitOfNewAsset);
                break;
            }

            return isFound;
        }

        public static bool AddToListOfFungibleAssets(FungibleAsset FungibleAssetToAddToList)
        {
            if (!ListsOfValidAssets.CheckIfUniqueFungibleAsset(FungibleAssetToAddToList.Name, FungibleAssetToAddToList.MeasuringUnit).Item1
                && !ListsOfValidAssets.CheckIfUniqueFungibleAsset(FungibleAssetToAddToList.Name, FungibleAssetToAddToList.MeasuringUnit).Item2)
            {
                ListOfFungibleAssets.Add(FungibleAssetToAddToList);
                return true;
            }
            return false;
        }
        //Checking if adress passsed to constructor of NonFungibleAsset class is actually an adress of some fungible asset and if it is adding it to the valid non fungilbe list
        public static bool CheckIfAdressIsPointingToAFungibleAsset(Guid AdressPointingToFungibleAsset) {
            foreach (FungibleAsset fungibleAsset in ListOfFungibleAssets) {
                if (!(fungibleAsset.AdressOfAsset == AdressPointingToFungibleAsset))
                    continue;

                 return true;
            }

            return false;
        }


        public static bool AddToListOfNonFungibleAssets(NonFungibleAsset NonFungibleAssetToAddToList) {
            if (CheckIfAdressIsPointingToAFungibleAsset(NonFungibleAssetToAddToList.AdressOfFungibleItemForValue))
            {
                ListOfNonFungibleAssets.Add(NonFungibleAssetToAddToList);
                return true;
            }
            return false;
        }

        public static void ChangeValueOfAnAsset(Guid PassedAdress) {
            foreach (NonFungibleAsset nonFungibleAsset in ListOfNonFungibleAssets) {
                if(nonFungibleAsset.AdressOfAsset == PassedAdress){
                    foreach(FungibleAsset fungibleAsset in ListOfFungibleAssets){
                        if (fungibleAsset.AdressOfAsset == nonFungibleAsset.AdressOfFungibleItemForValue){
                            fungibleAsset.ChangeValueInUSD();
                        }
                    }
                }
            }
            foreach (FungibleAsset fungibleAsset in ListOfFungibleAssets) {
                if (fungibleAsset.AdressOfAsset == PassedAdress) {
                    fungibleAsset.ChangeValueInUSD();
                }
            }
        }

        public static string GetExchangedAssetName(Guid AssetAdress)
        {
            foreach (FungibleAsset fungibleAsset in ListOfFungibleAssets)
            {
                if (fungibleAsset.AdressOfAsset == AssetAdress)
                    return fungibleAsset.Name;
            }
            foreach (NonFungibleAsset nonFungibleAsset in ListOfNonFungibleAssets) {
                if(nonFungibleAsset.AdressOfAsset == AssetAdress)
                    return nonFungibleAsset.Name;
            }
            return "";
        }

        public static bool CheckIfAssetExists(string PassedAdress) {
            foreach (var asset in ListOfFungibleAssets) {
                if (asset.AdressOfAsset.ToString() == PassedAdress)
                    return true;
            }
            foreach (var asset in ListOfNonFungibleAssets)
            {
                if (asset.AdressOfAsset.ToString() == PassedAdress)
                    return true;
            }
            return false;
        }
    }
}
