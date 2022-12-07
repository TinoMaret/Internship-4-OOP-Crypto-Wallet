﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Classes.Assets
{
    public abstract class Asset
    {
        public Guid AdressOfAsset { get; private set; }
        public string Name { get; private set; }
        public Asset(string NameOfNewAsset) {
            AdressOfAsset = Guid.NewGuid();
            Name = NameOfNewAsset;
        }


        public override string ToString()
        {
            return $"Adresa asseta - {AdressOfAsset} \n" +
                $"Ime asseta {Name}";
        }
    }
}
