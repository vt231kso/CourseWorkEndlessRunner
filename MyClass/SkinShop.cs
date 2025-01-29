using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass
{
    public static class SkinShop
    {
        private const int SkinPrice = 10;

        public static bool PurchaseSkin(string skinId, ref int coins, List<string> ownedSkins)
        {
            if (coins >= SkinPrice)
            {
                coins -= SkinPrice;
                ownedSkins.Add(skinId);
                return true;
            }
            return false;
        }
    }
}
