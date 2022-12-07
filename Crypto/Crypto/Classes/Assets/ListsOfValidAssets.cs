using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Classes.Assets
{
    public static class ListsOfValidAssets
    {
        public static List<FungibleAsset> ListOfFungibleAssets { get; } = new List<FungibleAsset>();
        public static List<NonFungibleAsset> ListOfNonFungibleAssets { get; } = new List<NonFungibleAsset>();

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
            var found = false;
            foreach (FungibleAsset fungibleAsset in ListOfFungibleAssets) {
                if (!(fungibleAsset.AdressOfAsset == AdressPointingToFungibleAsset))
                    continue;

                found = true;
            }

            return found;
        }

        public static bool AddToListOfNonFungibleAssets(NonFungibleAsset NonFungibleAssetToAddToList) {
            if (CheckIfAdressIsPointingToAFungibleAsset(NonFungibleAssetToAddToList.AdressOfFungibleItemForValue))
            {
                ListOfNonFungibleAssets.Add(NonFungibleAssetToAddToList);
                return true;
            }
            return false;
        }
    }
}
