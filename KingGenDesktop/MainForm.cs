using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KingGen.Net.Models;
#pragma warning disable CS4014

namespace KingGenDesktop
{
    public partial class MainForm : Form
    {
        public static readonly List<Alt> GeneratedAlts = new List<Alt>();
        public static MainForm Instance;

        public MainForm()
        {
            InitializeComponent();
            Instance = this;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);//Exit the program when the close button is clicked
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            generateButton.Text = "Generating...";
            #pragma warning disable CS4014
            KingGenInterface.Generate();
            KingGenInterface.GetProfileInfoAsync();
#pragma warning restore CS4014
            generateButton.Text = "Generate";
        }

        public void UpdateAltInfo(Alt alt)
        {
            try
            {
                if (alt != null)
                {
                    GeneratedAlts.Add(alt);
                    emailLabel.Text = @"Email: " + alt.Email;
                    passwordLabel.Text = @"Password: " + alt.Password;
                    altTextBox.Text = KingGenInterface.GetCombo(alt);
                    dataGridView.Rows.Add(alt.Email, alt.Password);
                    if (clipboardToggleSwitch.Checked)
                        Clipboard.SetText(KingGenInterface.GetCombo(alt));
                }
                else
                    stockLabel.Text = @"Stock: 0";
                Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Issue occured grabbing alt info this may have occured because of a slow/non-existant internet connection if not contact: Flash_#5420" + ex.Message, "Error Occured");
            }
        }

        public void UpdateProfileInfo(Profile profile)
        {
            try
            {
                if (profile != null)
                {
                    stockLabel.Text = @"Stock: " + profile.Stock;
                    usernameLabel.Text = @"Username: " + profile.Username;
                    generatedLabel.Text = @"Generated: " + profile.Generated;
                    generatedTodayLabel.Text = @"Generated Today: " + profile.GeneratedToday;
                }
                else
                    stockLabel.Text = @"Stock: 0";
                Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Issue occured grabbing alt info this may have occured because of a slow/non-existant internet connection if not contact: Flash_#5420" + ex.Message, "Error Occured");
            }
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            AltSaver.Load();
            KingGenInterface.GetProfileInfoAsync();
        }
    }
}
