using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KingGen.Net.Models;

namespace KingGenDesktop
{
    internal class KingGenInterface
    {
        static string getkey()
        {
            if (File.Exists("key.txt"))
            {
                return File.ReadAllText("key.txt");
            }
            else
            {
                File.Create("key.txt");
                MessageBox.Show("No key found | Please put your key in key.txt");
                return "";
            }
        }
        static KingGen.Net.KingGen kingGen = new KingGen.Net.KingGen(getkey());//Create our KingGen object

        public static async Task Generate()//Create a method to generate a new alt
        {
            Alt alt = await kingGen.GetAltAsync();//As simple as that
            if (alt != null)
            {
                if (alt.Stock != 0)
                {
                    MainForm.Instance.UpdateAltInfo(alt);//Update the alt info
                }
                else
                {
                    MainForm.Instance.UpdateAltInfo(null);//if stock is out then just return null
                }
            } else
            {
                MainForm.Instance.UpdateAltInfo(null);//If server returns 204 then it will show alt as null so we just send a null alt
            }
        }

        public static async Task GetProfileInfoAsync()
        {
            Profile profile = await kingGen.GetProfileAsync();//As simple as that
            if (profile != null)
            {
                MainForm.Instance.UpdateProfileInfo(profile);//Update the profile info
            }
            else
            {
                MainForm.Instance.UpdateProfileInfo(null);//Return null because no info :(
            }
        }

        public static string getCombo(Alt alt)
        {
            return alt.Email + ":" + alt.Password;
        }
    }
}
