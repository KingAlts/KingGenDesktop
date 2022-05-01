using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Windows.Forms;
using KingGen.Models;

namespace KingGenDesktop;

internal static class KingGenInterface
{
    private static string GetKey()
    {
        if (File.Exists("key.txt"))
        {
            return File.ReadAllText("key.txt");
        }

        File.Create("key.txt");
        MessageBox.Show(@"No key found | Please put your key in key.txt");
        Environment.Exit(0);
        return "";
    }

    [SuppressMessage("ReSharper", "ArrangeObjectCreationWhenTypeEvident")] 
    private static readonly KingGen.KingGen KingGen = new KingGen.KingGen(GetKey());//Create our KingGen object

    public static void Generate()//Create a method to generate a new alt
    {
        var alt = KingGen.GetAlt();//simple as that
        MainForm.Instance.UpdateAltInfo(alt);
    }

    public static void GetProfileInfoAsync()
    {
        var profile = KingGen.GetProfile();//simple as that
        MainForm.Instance.UpdateProfileInfo(profile);
    }

    public static string GetCombo(Alt alt)
    {
        return alt.Email + ":" + alt.Password;
    }
}