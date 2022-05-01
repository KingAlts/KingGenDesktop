using KingGen.Net.Models;
using Newtonsoft.Json;//Literally the best library ever
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
// ReSharper disable AssignNullToNotNullAttribute

namespace KingGenDesktop
{
    internal static class AltSaver
    {
        public static void Save()
        {
            try
            {
                if (MainForm.GeneratedAlts != null)
                {
                    List<Alt> savedAlts = JsonConvert.DeserializeObject<List<Alt>>(File.ReadAllText(@"alts.json"));
                    if (savedAlts != null)//If the alts in the file are not null then we append the file
                    {
                        savedAlts.AddRange(MainForm.GeneratedAlts);//Add all of the newely generated alts to the old list to create a combined list
                        File.WriteAllText("alts.json", JsonConvert.SerializeObject(savedAlts)); //Save said alts
                    }
                    else if (MainForm.GeneratedAlts.Count != 0)
                    {
                        File.WriteAllText("alts.json", JsonConvert.SerializeObject(MainForm.GeneratedAlts));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine($@"Error: {ex} | Contact Flash_5420 if this issue persists");
            }
        }

        public static void Load()
        {
            try
            {
                if (File.Exists("alts.json") && File.ReadAllText("alts.json") != "")
                {
                    MainForm.GeneratedAlts.AddRange(JsonConvert.DeserializeObject<List<Alt>>(File.ReadAllText(@"alts.json")));//Add the deserialized object list to the already generated list
                }
                else
                {
                    if (!File.Exists("alts.json"))
                        File.Create("alts.json");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Error: {ex} | Contact Flash_5420 if this issue persists");
            }
        }
    }
}
