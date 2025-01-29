using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace MyClass
{
    public class AudioManager
    {
        public static WindowsMediaPlayer wmp = new WindowsMediaPlayer();

        public static void PlayAudio(string filePath)
        {
            try
            {
                var data = DataManager.LoadData(); // Завантажуємо дані з JSON
                int volume = data.Volume; // Витягуємо гучність

                wmp.URL = filePath;
                wmp.settings.volume = volume;
                wmp.settings.setMode("loop", true);
                wmp.controls.play();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing sound: {ex.Message}");
            }
        }
    }
}
