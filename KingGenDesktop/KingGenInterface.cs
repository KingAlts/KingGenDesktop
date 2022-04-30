using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using KingGen.Models;

namespace KingGenDesktop
{
    internal static class KingGenInterface
    {
        static string Getkey()
        {
            if (File.Exists("key.txt"))
            {
                return File.ReadAllText("key.txt");
            }
            else
            {
                File.Create("key.txt");
                MessageBox.Show(@"No key found | Please put your key in key.txt");
                Environment.Exit(0);
                return "";
            }
        }

        [SuppressMessage("ReSharper", "ArrangeObjectCreationWhenTypeEvident")] 
        private static readonly KingGen.KingGen KingGen = new KingGen.KingGen(Getkey());//Create our KingGen object

        public static void Generate()//Create a method to generate a new alt
        {
            Alt alt = KingGen.GetAlt();//simple as that
            if (alt != null)
            {
                MainForm.Instance.UpdateAltInfo(alt);//Update the alt info
            }
            else
            {
                MainForm.Instance.UpdateAltInfo(null);//Return null because no info :(
            }
        }

        public static void GetProfileInfoAsync()
        {
            Profile profile = KingGen.GetProfile();//simple as that
            if (profile != null)
            {
                MainForm.Instance.UpdateProfileInfo(profile);//Update the profile info
            }
            else
            {
                MainForm.Instance.UpdateProfileInfo(null);//Return null because no info :(
            }
        }

        public static string GetCombo(Alt alt)
        {
            return alt.Email + ":" + alt.Password;
        }
    }
}
