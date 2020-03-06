using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Components
{
    public class Music
    {
        public static void Sound(string sound)
        {
            var myPlayer = new System.Media.SoundPlayer();
            if (sound == "intro")
            {
                myPlayer.SoundLocation = @"C:\\Users\\student\\Downloads\\01ThePrelude.wav";
                myPlayer.Play();
            }
            else if (sound == "battle")
            {
                myPlayer.SoundLocation = @"C:\\Users\\student\\Downloads\\08Fight1.wav";
                myPlayer.Play();
            }
            else if (sound == "victory")
            {
                myPlayer.SoundLocation = @"C:\\Users\\student\\Downloads\\09Fanfare.wav";
                myPlayer.Play();
            }
            else if (sound == "magicHeal")
            {
                var newPlayer = new System.Media.SoundPlayer();
                newPlayer.SoundLocation = @"C:\\Users\\student\\Downloads\\whitemagic.wav";
                newPlayer.Play();
            }
            else if (sound == "save")
            {
                myPlayer.SoundLocation = @"C:\\Users\\student\\Downloads\\99GoodNight.wav";
                myPlayer.Play();
            }
            else if (sound == "tense")
            {
                myPlayer.SoundLocation = @"C:\\Users\\student\\Downloads\\02RedWings.wav";
                myPlayer.Play();
            }
            else if (sound == "tensetown")
            {
                myPlayer.SoundLocation = @"C:\\Users\\student\\Downloads\\03KingdomBaron.wav";
                myPlayer.Play();
            }



        }
    }
}
