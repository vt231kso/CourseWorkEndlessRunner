using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass
{
    public class SkinManager
    {
        private readonly string skinFolderPath = "C:\\Users\\Sofia\\Desktop\\Endless Runner\\Endless Runner\\MyClass\\Resources\\";
        private readonly string[] skins = new string[]
        {
            "skins1.png", "skins7.png", "skins4.png", "skins5.png", "skins2.png", "skins6.png"
        };

        public string GetSkinPath(int skinIndex)
        {
            if (skinIndex >= 0 && skinIndex < skins.Length)
            {
                return Path.Combine(skinFolderPath, skins[skinIndex]);
            }
            throw new ArgumentException($"Invalid skin index: {skinIndex}. Valid range is from 0 to {skins.Length - 1}.");
        }

        public bool PurchaseSkin(string skinId, ref int coins, List<string> ownedSkins)
        {
           
            if (coins >= 10)
            {
                coins -= 10;
                ownedSkins.Add(skinId);
                return true;
            }
            return false;
        }
    }
}
