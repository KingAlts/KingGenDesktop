using KingGen.Models;
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
                    savedAlts.AddRange(MainForm.GeneratedAlts);
                    File.AppendAllText("alts.json", JsonConvert.SerializeObject(savedAlts));
                }
            }
            catch (Exception ex)
            {
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
                    File.Create("alts.json");
                    MessageBox.Show(@"No alts.json file found in the executing directory");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Error: {ex} | Contact Flash_5420 if this issue persists");
            }
        }
    }
}
