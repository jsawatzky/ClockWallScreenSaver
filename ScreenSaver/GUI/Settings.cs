using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ClockWallScreenSaver.GUI
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            LoadSettings();
        }

        //Save the users setting to the registry
        private void SaveSettings()
        {
            // Create or get existing Registry subkey
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\ClockWallScreensaver");

            if (hour12.Checked) key.SetValue("format", 12);
            else key.SetValue("format", 24);
            key.SetValue("background", background.BackColor.ToArgb());
            key.SetValue("clock", clock.BackColor.ToArgb());
            key.SetValue("hand", hand.BackColor.ToArgb());
        }

        //Get the users settings from the registry
        //If no settings use defaults
        private void LoadSettings()
        {
            // Get the value stored in the Registry
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClockWallScreensaver");
            if (key == null)
            {
                hour12.Checked = true;
                background.BackColor = Color.Black;
                clock.BackColor = Color.FromArgb(10, 10, 10);
                hand.BackColor = Color.FromArgb(100, 100, 100);
            } else
            {
                if ((int)key.GetValue("format") == 12) hour12.Checked = true;
                else hour24.Checked = true;
                background.BackColor = Color.FromArgb((int)key.GetValue("background"));
                clock.BackColor = Color.FromArgb((int)key.GetValue("clock"));
                hand.BackColor = Color.FromArgb((int)key.GetValue("hand"));
            }
        }

        //Open the color dialog for the background color
        private void background_Click(object sender, EventArgs e)
        {
            colorDialog.Color = background.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                background.BackColor = colorDialog.Color;
            }
        }

        //Open the color dialog for the clock color
        private void clock_Click(object sender, EventArgs e)
        {
            colorDialog.Color = clock.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                clock.BackColor = colorDialog.Color;
            }
        }

        //Open the color dialog for the hand color
        private void hand_Click(object sender, EventArgs e)
        {
            colorDialog.Color = hand.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                hand.BackColor = colorDialog.Color;
            }
        }

        //Handle when the user hits save
        private void save_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }

        //Handle when the user hits cancel
        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Reset settings to defualts
        private void defaul_Click(object sender, EventArgs e)
        {
            hour12.Checked = true;
            background.BackColor = Color.Black;
            clock.BackColor = Color.FromArgb(10, 10, 10);
            hand.BackColor = Color.FromArgb(100, 100, 100);
        }
    }
}
