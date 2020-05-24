namespace TWW_Coop
{
    partial class MainForm
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
            this.modeBox = new System.Windows.Forms.ComboBox();
            this.consoleBox = new System.Windows.Forms.TextBox();
            this.dolphinListener = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // modeBox
            // 
            this.modeBox.FormattingEnabled = true;
            this.modeBox.Items.AddRange(new object[] {
            "Offline",
            "Client",
            "Server"});
            this.modeBox.Location = new System.Drawing.Point(23, 55);
            this.modeBox.Name = "modeBox";
            this.modeBox.Size = new System.Drawing.Size(162, 21);
            this.modeBox.TabIndex = 0;
            this.modeBox.SelectedIndexChanged += new System.EventHandler(this.modeBox_SelectedIndexChanged);
            // 
            // consoleBox
            // 
            this.consoleBox.Location = new System.Drawing.Point(12, 175);
            this.consoleBox.Multiline = true;
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ReadOnly = true;
            this.consoleBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleBox.Size = new System.Drawing.Size(376, 263);
            this.consoleBox.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.modeBox);
            this.Name = "MainForm";
            this.Text = "TWW Coop";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox modeBox;
        private System.Windows.Forms.TextBox consoleBox;
        private System.ComponentModel.BackgroundWorker dolphinListener;
    }
}

