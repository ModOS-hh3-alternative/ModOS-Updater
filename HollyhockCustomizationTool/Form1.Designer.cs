namespace HollyhockCustomizationTool
{
    partial class HollyhockCustomizer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HollyhockCustomizer));
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.outputGroupBox = new System.Windows.Forms.GroupBox();
            this.customRomTextBox = new System.Windows.Forms.TextBox();
            this.optionsGroupBox = new System.Windows.Forms.GroupBox();
            this.launcherFileNameLabel = new System.Windows.Forms.Label();
            this.launcherFileNameTextBox = new System.Windows.Forms.TextBox();
            this.hollyhockMenuStringLabel = new System.Windows.Forms.Label();
            this.launcherMenuTextBox = new System.Windows.Forms.TextBox();
            this.versionStringLabel = new System.Windows.Forms.Label();
            this.versionStringTextBox = new System.Windows.Forms.TextBox();
            this.browseFilesButton = new System.Windows.Forms.Button();
            this.customFirmwareCheckBox = new System.Windows.Forms.CheckBox();
            this.flashRomGroupBox = new System.Windows.Forms.GroupBox();
            this.flashRomButton = new System.Windows.Forms.Button();
            this.githubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.discordLinkLabel = new System.Windows.Forms.LinkLabel();
            this.outputGroupBox.SuspendLayout();
            this.optionsGroupBox.SuspendLayout();
            this.flashRomGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputBox
            // 
            this.outputBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.outputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputBox.Location = new System.Drawing.Point(69, 19);
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(638, 72);
            this.outputBox.TabIndex = 0;
            this.outputBox.Text = "";
            // 
            // outputGroupBox
            // 
            this.outputGroupBox.Controls.Add(this.outputBox);
            this.outputGroupBox.Location = new System.Drawing.Point(48, 351);
            this.outputGroupBox.Name = "outputGroupBox";
            this.outputGroupBox.Size = new System.Drawing.Size(739, 100);
            this.outputGroupBox.TabIndex = 1;
            this.outputGroupBox.TabStop = false;
            this.outputGroupBox.Text = "Output";
            // 
            // customRomTextBox
            // 
            this.customRomTextBox.Enabled = false;
            this.customRomTextBox.Location = new System.Drawing.Point(51, 42);
            this.customRomTextBox.Name = "customRomTextBox";
            this.customRomTextBox.ReadOnly = true;
            this.customRomTextBox.Size = new System.Drawing.Size(519, 20);
            this.customRomTextBox.TabIndex = 2;
            // 
            // optionsGroupBox
            // 
            this.optionsGroupBox.Controls.Add(this.launcherFileNameLabel);
            this.optionsGroupBox.Controls.Add(this.launcherFileNameTextBox);
            this.optionsGroupBox.Controls.Add(this.hollyhockMenuStringLabel);
            this.optionsGroupBox.Controls.Add(this.launcherMenuTextBox);
            this.optionsGroupBox.Controls.Add(this.versionStringLabel);
            this.optionsGroupBox.Controls.Add(this.versionStringTextBox);
            this.optionsGroupBox.Controls.Add(this.browseFilesButton);
            this.optionsGroupBox.Controls.Add(this.customFirmwareCheckBox);
            this.optionsGroupBox.Controls.Add(this.customRomTextBox);
            this.optionsGroupBox.Location = new System.Drawing.Point(48, 12);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.Size = new System.Drawing.Size(739, 272);
            this.optionsGroupBox.TabIndex = 2;
            this.optionsGroupBox.TabStop = false;
            this.optionsGroupBox.Text = "Options";
            // 
            // launcherFileNameLabel
            // 
            this.launcherFileNameLabel.AutoSize = true;
            this.launcherFileNameLabel.Location = new System.Drawing.Point(48, 186);
            this.launcherFileNameLabel.Name = "launcherFileNameLabel";
            this.launcherFileNameLabel.Size = new System.Drawing.Size(102, 13);
            this.launcherFileNameLabel.TabIndex = 11;
            this.launcherFileNameLabel.Text = "Launcher File Name";
            // 
            // launcherFileNameTextBox
            // 
            this.launcherFileNameTextBox.Location = new System.Drawing.Point(51, 205);
            this.launcherFileNameTextBox.MaxLength = 7;
            this.launcherFileNameTextBox.Name = "launcherFileNameTextBox";
            this.launcherFileNameTextBox.Size = new System.Drawing.Size(656, 20);
            this.launcherFileNameTextBox.TabIndex = 10;
            this.launcherFileNameTextBox.Text = "run.bin";
            // 
            // hollyhockMenuStringLabel
            // 
            this.hollyhockMenuStringLabel.AutoSize = true;
            this.hollyhockMenuStringLabel.Location = new System.Drawing.Point(48, 76);
            this.hollyhockMenuStringLabel.Name = "hollyhockMenuStringLabel";
            this.hollyhockMenuStringLabel.Size = new System.Drawing.Size(156, 13);
            this.hollyhockMenuStringLabel.TabIndex = 8;
            this.hollyhockMenuStringLabel.Text = "Hollyhock Launcher Menu Text";
            // 
            // launcherMenuTextBox
            // 
            this.launcherMenuTextBox.Location = new System.Drawing.Point(51, 95);
            this.launcherMenuTextBox.MaxLength = 18;
            this.launcherMenuTextBox.Name = "launcherMenuTextBox";
            this.launcherMenuTextBox.Size = new System.Drawing.Size(656, 20);
            this.launcherMenuTextBox.TabIndex = 7;
            this.launcherMenuTextBox.Text = "Hollyhock Launcher";
            // 
            // versionStringLabel
            // 
            this.versionStringLabel.AutoSize = true;
            this.versionStringLabel.Location = new System.Drawing.Point(48, 130);
            this.versionStringLabel.Name = "versionStringLabel";
            this.versionStringLabel.Size = new System.Drawing.Size(66, 13);
            this.versionStringLabel.TabIndex = 6;
            this.versionStringLabel.Text = "Version Text";
            // 
            // versionStringTextBox
            // 
            this.versionStringTextBox.Location = new System.Drawing.Point(51, 149);
            this.versionStringTextBox.MaxLength = 11;
            this.versionStringTextBox.Name = "versionStringTextBox";
            this.versionStringTextBox.Size = new System.Drawing.Size(656, 20);
            this.versionStringTextBox.TabIndex = 5;
            this.versionStringTextBox.Text = "hollyhock-3";
            // 
            // browseFilesButton
            // 
            this.browseFilesButton.Enabled = false;
            this.browseFilesButton.Location = new System.Drawing.Point(586, 40);
            this.browseFilesButton.Name = "browseFilesButton";
            this.browseFilesButton.Size = new System.Drawing.Size(121, 25);
            this.browseFilesButton.TabIndex = 4;
            this.browseFilesButton.Text = "Browse Files";
            this.browseFilesButton.UseVisualStyleBackColor = true;
            this.browseFilesButton.Click += new System.EventHandler(this.browseFilesButton_Click);
            // 
            // customFirmwareCheckBox
            // 
            this.customFirmwareCheckBox.AutoSize = true;
            this.customFirmwareCheckBox.Location = new System.Drawing.Point(51, 19);
            this.customFirmwareCheckBox.Name = "customFirmwareCheckBox";
            this.customFirmwareCheckBox.Size = new System.Drawing.Size(141, 17);
            this.customFirmwareCheckBox.TabIndex = 3;
            this.customFirmwareCheckBox.Text = "Use own firmware binary";
            this.customFirmwareCheckBox.UseVisualStyleBackColor = true;
            this.customFirmwareCheckBox.CheckedChanged += new System.EventHandler(this.customFirmwareCheckBox_CheckedChanged);
            // 
            // flashRomGroupBox
            // 
            this.flashRomGroupBox.Controls.Add(this.flashRomButton);
            this.flashRomGroupBox.Location = new System.Drawing.Point(48, 290);
            this.flashRomGroupBox.Name = "flashRomGroupBox";
            this.flashRomGroupBox.Size = new System.Drawing.Size(739, 53);
            this.flashRomGroupBox.TabIndex = 12;
            this.flashRomGroupBox.TabStop = false;
            this.flashRomGroupBox.Text = "Flash ROM";
            // 
            // flashRomButton
            // 
            this.flashRomButton.Location = new System.Drawing.Point(632, 19);
            this.flashRomButton.Name = "flashRomButton";
            this.flashRomButton.Size = new System.Drawing.Size(75, 23);
            this.flashRomButton.TabIndex = 0;
            this.flashRomButton.Text = "Flash ROM";
            this.flashRomButton.UseVisualStyleBackColor = true;
            this.flashRomButton.Click += new System.EventHandler(this.flashRomButton_Click);
            // 
            // githubLinkLabel
            // 
            this.githubLinkLabel.AutoSize = true;
            this.githubLinkLabel.LinkColor = System.Drawing.Color.Black;
            this.githubLinkLabel.Location = new System.Drawing.Point(2, 458);
            this.githubLinkLabel.Name = "githubLinkLabel";
            this.githubLinkLabel.Size = new System.Drawing.Size(38, 13);
            this.githubLinkLabel.TabIndex = 13;
            this.githubLinkLabel.TabStop = true;
            this.githubLinkLabel.Text = "Github";
            this.githubLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubLinkLabel_LinkClicked);
            // 
            // discordLinkLabel
            // 
            this.discordLinkLabel.AutoSize = true;
            this.discordLinkLabel.LinkColor = System.Drawing.Color.Black;
            this.discordLinkLabel.Location = new System.Drawing.Point(45, 458);
            this.discordLinkLabel.Name = "discordLinkLabel";
            this.discordLinkLabel.Size = new System.Drawing.Size(43, 13);
            this.discordLinkLabel.TabIndex = 14;
            this.discordLinkLabel.TabStop = true;
            this.discordLinkLabel.Text = "Discord";
            this.discordLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.discordLinkLabel_LinkClicked);
            // 
            // HollyhockCustomizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 480);
            this.Controls.Add(this.discordLinkLabel);
            this.Controls.Add(this.githubLinkLabel);
            this.Controls.Add(this.flashRomGroupBox);
            this.Controls.Add(this.outputGroupBox);
            this.Controls.Add(this.optionsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HollyhockCustomizer";
            this.Text = "Hollyhock Customizer";
            this.outputGroupBox.ResumeLayout(false);
            this.optionsGroupBox.ResumeLayout(false);
            this.optionsGroupBox.PerformLayout();
            this.flashRomGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox outputBox;
        private System.Windows.Forms.GroupBox outputGroupBox;
        private System.Windows.Forms.TextBox customRomTextBox;
        private System.Windows.Forms.GroupBox optionsGroupBox;
        private System.Windows.Forms.CheckBox customFirmwareCheckBox;
        private System.Windows.Forms.Button browseFilesButton;
        private System.Windows.Forms.Label versionStringLabel;
        private System.Windows.Forms.TextBox versionStringTextBox;
        private System.Windows.Forms.Label hollyhockMenuStringLabel;
        private System.Windows.Forms.TextBox launcherMenuTextBox;
        private System.Windows.Forms.Label launcherFileNameLabel;
        private System.Windows.Forms.TextBox launcherFileNameTextBox;
        private System.Windows.Forms.GroupBox flashRomGroupBox;
        private System.Windows.Forms.Button flashRomButton;
        private System.Windows.Forms.LinkLabel githubLinkLabel;
        private System.Windows.Forms.LinkLabel discordLinkLabel;
    }
}

