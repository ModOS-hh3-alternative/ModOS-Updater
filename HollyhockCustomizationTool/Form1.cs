using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace HollyhockCustomizationTool
{
    public partial class HollyhockCustomizer : Form
    {
        bool hollyhockInstallationChanged = false;
        bool usingCustomBinary = false;
        string filePath = string.Empty;

        public HollyhockCustomizer()
        {
            InitializeComponent();
            if (!Checksum.Verify("OSupdateDLL_original.dll", "5402d6e0d8e7342fd81e2609c0984047") || !File.Exists("OSupdateDLL_original.dll"))
            {
                MessageBox.Show(
                    "OSupdateDLL.dll could not be verifyed,\nplease reinstall OSupdateDLL.dll,\nput it beside the .exe and try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

                Environment.Exit(0);
            }

            if (!Checksum.Verify("fxASPI.dll", "7822fb1aabadeb5d8ef6d32bf11c9628") || !File.Exists("fxASPI.dll"))
            {
                MessageBox.Show(
                    "fxASPI.dll could not be verifyed,\nplease reinstall fxASPI.dll,\nput it beside the .exe and try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

                Environment.Exit(0);
            }

            if (!Checksum.Verify("LanguageResource.dll", "1c79743f7ab84239962b71a7f34f195d") || !File.Exists("LanguageResource.dll"))
            {
                MessageBox.Show(
                    "LanguageResource.dll could not be verifyed,\nplease reinstall LanguageResource.dll,\nput it beside the .exe and try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

                Environment.Exit(0);
            }

            if (!Checksum.Verify("messages.txt", "93a4955736d0189674191f7f3c16a547") || !File.Exists("messages.txt"))
            {
                MessageBox.Show(
                    "messages.txt could not be verifyed,\nplease reinstall messages.txt,\nput it beside the .exe and try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

                Environment.Exit(0);
            }
        }

        private void customFirmwareCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (customFirmwareCheckBox.Checked)
            {
                usingCustomBinary = true;

                customRomTextBox.Enabled = !customRomTextBox.Enabled;
                browseFilesButton.Enabled = !browseFilesButton.Enabled;

                launcherMenuTextBox.Enabled = !launcherMenuTextBox.Enabled;
                versionStringTextBox.Enabled = !versionStringTextBox.Enabled;
                launcherFileNameTextBox.Enabled = !launcherFileNameTextBox.Enabled;
            }

            else
            {
                usingCustomBinary = false;

                customRomTextBox.Enabled = !customRomTextBox.Enabled;
                browseFilesButton.Enabled = !browseFilesButton.Enabled;

                launcherMenuTextBox.Enabled = !launcherMenuTextBox.Enabled;
                versionStringTextBox.Enabled = !versionStringTextBox.Enabled;
                launcherFileNameTextBox.Enabled = !launcherFileNameTextBox.Enabled;
            }
        }

        private void browseFilesButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }

            customRomTextBox.Text = filePath;
        }

        private void flashRomButton_Click(object sender, EventArgs e)
        {
            outputBox.Text = null;

            List<byte> menuTextBytes = new List<byte>(Encoding.UTF8.GetBytes(launcherMenuTextBox.Text));
            List<byte> versionTextBytes = new List<byte>(Encoding.UTF8.GetBytes(versionStringTextBox.Text));
            List<byte> launcherFileNameBytes = new List<byte>(Encoding.UTF8.GetBytes(launcherFileNameTextBox.Text));

            while (menuTextBytes.Count < 18)
                menuTextBytes.Add(0x00);

            while (versionTextBytes.Count < 11)
                versionTextBytes.Add(0x00);

            while (launcherFileNameBytes.Count < 7)
                launcherFileNameBytes.Add(0x00);

            if (menuTextBytes.Count > 18)
            {
                outputBox.Text += "Hollyhock Launcher Menu Text is bigger than 18 bytes!\n";
                File.WriteAllText("output.txt", outputBox.Text);
                return;
            }

            if (versionTextBytes.Count > 11)
            {
                outputBox.Text += "Version Text is bigger than 11 bytes!\n";
                File.WriteAllText("output.txt", outputBox.Text);
                return;
            }

            if (launcherFileNameBytes.Count > 7)
            {
                outputBox.Text += "Launcher File Name is bigger than 7 bytes!\n";
                File.WriteAllText("output.txt", outputBox.Text);
                return;
            }

            if (launcherMenuTextBox.Text == "Hollyhock Launcher" && versionStringTextBox.Text == "hollyhock-3" && launcherFileNameTextBox.Text == "run.bin")
            {
                hollyhockInstallationChanged = false;
            }

            else
            {
                hollyhockInstallationChanged = true;
            }

            if (!usingCustomBinary && hollyhockInstallationChanged)
            {
                outputBox.Text += "Extracting RCDATA_3070...\n";
                string DumpRcData = Resources.DumpRcData("OSupdateDLL_original.dll", 3070);
                if (DumpRcData == null)
                {
                    outputBox.Text += "Extracted RCDATA_3070!\n";
                    outputBox.Text += "Verifying RCDATA_3070...\n";

                    if (!Checksum.Verify("RCDATA_3070.bin", "e2436d14f75f39dfa97776b0a6aec3cb"))
                    {
                        outputBox.Text += "Verification failed! Please try again.\n";
                        File.WriteAllText("output.txt", outputBox.Text);
                    }

                    else
                    { 
                        outputBox.Text += "Verification successfull!\n";
                        outputBox.Text += "Decompressing RCDATA_3070...\n";
                        string DecompressFirmware = Resources.DecompressFirmware();

                        if (DecompressFirmware == null)
                        {
                            outputBox.Text += "Successfully decompressed RCDATA_3070!\n";
                            outputBox.Text += "Verifying decompressed RCDATA_3070...\n";

                            if (!Checksum.Verify("decompressed.bin", "0187b77f646766617fd80c9173286239"))
                            {
                                outputBox.Text += "Verification failed! Please try again.\n";
                                File.WriteAllText("output.txt", outputBox.Text);
                            }

                            else
                            {
                                outputBox.Text += "Verification successfull!\n";
                                outputBox.Text += "Modifying Firmware...\n";

                                //please no error...
                                //im to lazy to add exception handling
                                Resources.ModifyFirmware(menuTextBytes.ToArray(), 9276872);
                                Resources.ModifyFirmware(versionTextBytes.ToArray(), 9567952);
                                Resources.ModifyFirmware(launcherFileNameBytes.ToArray(), 1216802);

                                outputBox.Text += "Modification successfull!\n";
                                outputBox.Text += "Recompressing firmware...\n";
                                string RecompressFirmware = Resources.RecompressFirmware();

                                if (RecompressFirmware == null)
                                {
                                    outputBox.Text += "Firmware successfully recompressed!\n";
                                    outputBox.Text += "Replacing RCDATA_3070...\n";
                                    string ReplaceRcData = Resources.ReplaceRcData();

                                    if (ReplaceRcData == null)
                                    {
                                        outputBox.Text += "Successfully replaced RCDATA_3070!\n";
                                        outputBox.Text += "Calling the OSUpdate function...\n";

                                        File.WriteAllText("output.txt", outputBox.Text);
                                        Process.Start("https://classpaddev.github.io/first-run");
                                        string InitModifiedOSUpdate = OSUpdater.InitModifiedOSUpdate();

                                        if (InitModifiedOSUpdate != null)
                                        {
                                            outputBox.Text += $"Calling the OSUpdate function failed!\n{InitModifiedOSUpdate}";
                                            File.AppendAllText("output.txt", outputBox.Text);
                                        }
                                    }

                                    else
                                    {
                                        outputBox.Text += $"Replacing resources failed!\n{ReplaceRcData}";
                                        File.WriteAllText("output.txt", outputBox.Text);
                                    }
                                }

                                else
                                {
                                    outputBox.Text += $"Recompressing firmware failed!\n{RecompressFirmware}";
                                    File.WriteAllText("output.txt", outputBox.Text);
                                }
                            }
                        }

                        else
                        {
                            outputBox.Text += $"Decompressing RCDATA_3070 failed!\n{DecompressFirmware}";
                            File.WriteAllText("output.txt", outputBox.Text);
                        }
                    }
                }

                else
                {
                    outputBox.Text += $"Extracting RCDATA_3070 failed!\n{DumpRcData}";
                    File.WriteAllText("output.txt", outputBox.Text);
                }
            }

            else if (!hollyhockInstallationChanged && !usingCustomBinary)
            {
                outputBox.Text += "Calling the OSUpdate function...\n";
                File.WriteAllText("output.txt", outputBox.Text);
                Process.Start("https://classpaddev.github.io/first-run");
                string InitOSUpdate = OSUpdater.InitOSUpdate();
                if (InitOSUpdate != null)
                {
                    outputBox.Text += $"Calling the OSUpdate function failed!\n{InitOSUpdate}";
                    File.AppendAllText("output.txt", outputBox.Text);
                }
            }

            else if (usingCustomBinary)
            {
                if (!File.Exists(customRomTextBox.Text))
                {
                    outputBox.Text += "File not found!";
                    File.WriteAllText("output.txt", outputBox.Text);
                    return;
                }

                File.Copy(customRomTextBox.Text, "decompressed.bin", true);
                outputBox.Text += "Compressing firmware...\n";
                string RecompressFirmware = Resources.RecompressFirmware();
                if (RecompressFirmware == null)
                {
                    outputBox.Text += "Successfully compressed the firmware!\n";
                    outputBox.Text += "Replacing RCDATA_3070...\n";
                    string ReplaceRcData = Resources.ReplaceRcData();
                    if (ReplaceRcData == null)
                    {
                        outputBox.Text += "Successfully replaced RCDATA_3070!\n";
                        outputBox.Text += "Calling the OSUpdate function...\n";
                        File.WriteAllText("output.txt", outputBox.Text);
                        Process.Start("https://classpaddev.github.io/first-run");
                        string InitModifiedOSUpdate = OSUpdater.InitModifiedOSUpdate();

                        if (InitModifiedOSUpdate != null)
                        {
                            outputBox.Text += $"Calling the OSUpdate function failed!\n{InitModifiedOSUpdate}";
                            File.AppendAllText("output.txt", outputBox.Text);
                        }
                    }

                    else
                    {
                        outputBox.Text += $"Replacing resources failed!\n{ReplaceRcData}";
                        File.WriteAllText("output.txt", outputBox.Text);
                    }
                }

                else
                {
                    outputBox.Text += $"Recompressing firmware failed!\n{RecompressFirmware}";
                    File.WriteAllText("output.txt", outputBox.Text);
                }
            }
        }

        private void githubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("https://www.github.com/PyCSharp/");
            }

            catch
            {
                //nothing, lol
            }
        }

        private void discordLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("https://discord.gg/knpcNJTzpd");
            }

            catch
            {
                //nothing, lol
            }
        }
    }
}
