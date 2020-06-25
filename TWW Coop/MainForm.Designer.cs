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
            this.swordPicture = new System.Windows.Forms.PictureBox();
            this.telescopePicture = new System.Windows.Forms.PictureBox();
            this.sailPicture = new System.Windows.Forms.PictureBox();
            this.wwPicture = new System.Windows.Forms.PictureBox();
            this.grapplingHookPicture = new System.Windows.Forms.PictureBox();
            this.spoilsBagPicture = new System.Windows.Forms.PictureBox();
            this.boomerangPicture = new System.Windows.Forms.PictureBox();
            this.dekuLeafPicture = new System.Windows.Forms.PictureBox();
            this.bombsPicture = new System.Windows.Forms.PictureBox();
            this.bowPicture = new System.Windows.Forms.PictureBox();
            this.baitBagPicture = new System.Windows.Forms.PictureBox();
            this.magicArmorPicture = new System.Windows.Forms.PictureBox();
            this.ironBootsPicture = new System.Windows.Forms.PictureBox();
            this.pictoBoxPicture = new System.Windows.Forms.PictureBox();
            this.tingleTunerPicture = new System.Windows.Forms.PictureBox();
            this.shieldPicture = new System.Windows.Forms.PictureBox();
            this.nayruPicture = new System.Windows.Forms.PictureBox();
            this.dinPicture = new System.Windows.Forms.PictureBox();
            this.farorePicture = new System.Windows.Forms.PictureBox();
            this.testButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.swordPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.telescopePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sailPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wwPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grapplingHookPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spoilsBagPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boomerangPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dekuLeafPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bombsPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bowPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baitBagPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.magicArmorPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ironBootsPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictoBoxPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tingleTunerPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shieldPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nayruPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dinPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.farorePicture)).BeginInit();
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
            // swordPicture
            // 
            this.swordPicture.Image = global::TWW_Coop.Resources.item_SwordN;
            this.swordPicture.Location = new System.Drawing.Point(850, 114);
            this.swordPicture.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.swordPicture.Name = "swordPicture";
            this.swordPicture.Size = new System.Drawing.Size(51, 52);
            this.swordPicture.TabIndex = 2;
            this.swordPicture.TabStop = false;
            // 
            // telescopePicture
            // 
            this.telescopePicture.Image = global::TWW_Coop.Resources.item_TelescopeN;
            this.telescopePicture.Location = new System.Drawing.Point(427, 114);
            this.telescopePicture.Name = "telescopePicture";
            this.telescopePicture.Size = new System.Drawing.Size(51, 52);
            this.telescopePicture.TabIndex = 3;
            this.telescopePicture.TabStop = false;
            this.telescopePicture.Click += new System.EventHandler(this.telescopePicture_Click);
            // 
            // sailPicture
            // 
            this.sailPicture.Image = global::TWW_Coop.Resources.item_SwiftSailN;
            this.sailPicture.Location = new System.Drawing.Point(484, 114);
            this.sailPicture.Name = "sailPicture";
            this.sailPicture.Size = new System.Drawing.Size(51, 52);
            this.sailPicture.TabIndex = 4;
            this.sailPicture.TabStop = false;
            // 
            // wwPicture
            // 
            this.wwPicture.Image = global::TWW_Coop.Resources.item_WindWakerN;
            this.wwPicture.Location = new System.Drawing.Point(541, 114);
            this.wwPicture.Name = "wwPicture";
            this.wwPicture.Size = new System.Drawing.Size(51, 52);
            this.wwPicture.TabIndex = 5;
            this.wwPicture.TabStop = false;
            // 
            // grapplingHookPicture
            // 
            this.grapplingHookPicture.Image = global::TWW_Coop.Resources.item_GrapplingHookN;
            this.grapplingHookPicture.Location = new System.Drawing.Point(598, 114);
            this.grapplingHookPicture.Name = "grapplingHookPicture";
            this.grapplingHookPicture.Size = new System.Drawing.Size(51, 52);
            this.grapplingHookPicture.TabIndex = 6;
            this.grapplingHookPicture.TabStop = false;
            // 
            // spoilsBagPicture
            // 
            this.spoilsBagPicture.Image = global::TWW_Coop.Resources.bag_SpoilsBagN;
            this.spoilsBagPicture.Location = new System.Drawing.Point(655, 114);
            this.spoilsBagPicture.Name = "spoilsBagPicture";
            this.spoilsBagPicture.Size = new System.Drawing.Size(51, 52);
            this.spoilsBagPicture.TabIndex = 7;
            this.spoilsBagPicture.TabStop = false;
            // 
            // boomerangPicture
            // 
            this.boomerangPicture.Image = global::TWW_Coop.Resources.item_BoomerangN;
            this.boomerangPicture.Location = new System.Drawing.Point(712, 114);
            this.boomerangPicture.Name = "boomerangPicture";
            this.boomerangPicture.Size = new System.Drawing.Size(51, 52);
            this.boomerangPicture.TabIndex = 8;
            this.boomerangPicture.TabStop = false;
            // 
            // dekuLeafPicture
            // 
            this.dekuLeafPicture.Image = global::TWW_Coop.Resources.item_DekuLeafN;
            this.dekuLeafPicture.Location = new System.Drawing.Point(769, 114);
            this.dekuLeafPicture.Name = "dekuLeafPicture";
            this.dekuLeafPicture.Size = new System.Drawing.Size(51, 52);
            this.dekuLeafPicture.TabIndex = 9;
            this.dekuLeafPicture.TabStop = false;
            // 
            // bombsPicture
            // 
            this.bombsPicture.Image = global::TWW_Coop.Resources.item_BombN;
            this.bombsPicture.Location = new System.Drawing.Point(769, 175);
            this.bombsPicture.Name = "bombsPicture";
            this.bombsPicture.Size = new System.Drawing.Size(51, 52);
            this.bombsPicture.TabIndex = 17;
            this.bombsPicture.TabStop = false;
            // 
            // bowPicture
            // 
            this.bowPicture.Image = global::TWW_Coop.Resources.item_BowN;
            this.bowPicture.Location = new System.Drawing.Point(712, 175);
            this.bowPicture.Name = "bowPicture";
            this.bowPicture.Size = new System.Drawing.Size(51, 52);
            this.bowPicture.TabIndex = 16;
            this.bowPicture.TabStop = false;
            // 
            // baitBagPicture
            // 
            this.baitBagPicture.Image = global::TWW_Coop.Resources.bag_BaitBagN;
            this.baitBagPicture.Location = new System.Drawing.Point(655, 175);
            this.baitBagPicture.Name = "baitBagPicture";
            this.baitBagPicture.Size = new System.Drawing.Size(51, 52);
            this.baitBagPicture.TabIndex = 15;
            this.baitBagPicture.TabStop = false;
            // 
            // magicArmorPicture
            // 
            this.magicArmorPicture.Image = global::TWW_Coop.Resources.item_MagicArmorN;
            this.magicArmorPicture.Location = new System.Drawing.Point(598, 175);
            this.magicArmorPicture.Name = "magicArmorPicture";
            this.magicArmorPicture.Size = new System.Drawing.Size(51, 52);
            this.magicArmorPicture.TabIndex = 14;
            this.magicArmorPicture.TabStop = false;
            // 
            // ironBootsPicture
            // 
            this.ironBootsPicture.Image = global::TWW_Coop.Resources.item_IronBootsN;
            this.ironBootsPicture.Location = new System.Drawing.Point(541, 175);
            this.ironBootsPicture.Name = "ironBootsPicture";
            this.ironBootsPicture.Size = new System.Drawing.Size(51, 52);
            this.ironBootsPicture.TabIndex = 13;
            this.ironBootsPicture.TabStop = false;
            // 
            // pictoBoxPicture
            // 
            this.pictoBoxPicture.Image = global::TWW_Coop.Resources.item_PictoBoxN;
            this.pictoBoxPicture.Location = new System.Drawing.Point(484, 175);
            this.pictoBoxPicture.Name = "pictoBoxPicture";
            this.pictoBoxPicture.Size = new System.Drawing.Size(51, 52);
            this.pictoBoxPicture.TabIndex = 12;
            this.pictoBoxPicture.TabStop = false;
            // 
            // tingleTunerPicture
            // 
            this.tingleTunerPicture.Image = global::TWW_Coop.Resources.item_TingleTunerN;
            this.tingleTunerPicture.Location = new System.Drawing.Point(427, 175);
            this.tingleTunerPicture.Name = "tingleTunerPicture";
            this.tingleTunerPicture.Size = new System.Drawing.Size(51, 52);
            this.tingleTunerPicture.TabIndex = 11;
            this.tingleTunerPicture.TabStop = false;
            // 
            // shieldPicture
            // 
            this.shieldPicture.Image = global::TWW_Coop.Resources.item_ShieldN;
            this.shieldPicture.Location = new System.Drawing.Point(850, 175);
            this.shieldPicture.Name = "shieldPicture";
            this.shieldPicture.Size = new System.Drawing.Size(51, 52);
            this.shieldPicture.TabIndex = 10;
            this.shieldPicture.TabStop = false;
            // 
            // nayruPicture
            // 
            this.nayruPicture.Image = global::TWW_Coop.Resources.pearl_NayruN;
            this.nayruPicture.Location = new System.Drawing.Point(484, 319);
            this.nayruPicture.Name = "nayruPicture";
            this.nayruPicture.Size = new System.Drawing.Size(33, 33);
            this.nayruPicture.TabIndex = 18;
            this.nayruPicture.TabStop = false;
            // 
            // dinPicture
            // 
            this.dinPicture.Image = global::TWW_Coop.Resources.pearl_DinN;
            this.dinPicture.Location = new System.Drawing.Point(458, 365);
            this.dinPicture.Name = "dinPicture";
            this.dinPicture.Size = new System.Drawing.Size(33, 33);
            this.dinPicture.TabIndex = 19;
            this.dinPicture.TabStop = false;
            // 
            // farorePicture
            // 
            this.farorePicture.Image = global::TWW_Coop.Resources.pearl_FaroreN;
            this.farorePicture.Location = new System.Drawing.Point(509, 365);
            this.farorePicture.Name = "farorePicture";
            this.farorePicture.Size = new System.Drawing.Size(33, 33);
            this.farorePicture.TabIndex = 20;
            this.farorePicture.TabStop = false;
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(647, 396);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(150, 41);
            this.testButton.TabIndex = 21;
            this.testButton.Text = "Give Picto2";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(913, 497);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.farorePicture);
            this.Controls.Add(this.dinPicture);
            this.Controls.Add(this.nayruPicture);
            this.Controls.Add(this.bombsPicture);
            this.Controls.Add(this.bowPicture);
            this.Controls.Add(this.baitBagPicture);
            this.Controls.Add(this.magicArmorPicture);
            this.Controls.Add(this.ironBootsPicture);
            this.Controls.Add(this.pictoBoxPicture);
            this.Controls.Add(this.tingleTunerPicture);
            this.Controls.Add(this.shieldPicture);
            this.Controls.Add(this.dekuLeafPicture);
            this.Controls.Add(this.boomerangPicture);
            this.Controls.Add(this.spoilsBagPicture);
            this.Controls.Add(this.grapplingHookPicture);
            this.Controls.Add(this.wwPicture);
            this.Controls.Add(this.sailPicture);
            this.Controls.Add(this.telescopePicture);
            this.Controls.Add(this.swordPicture);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.modeBox);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "TWW Coop";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.swordPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.telescopePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sailPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wwPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grapplingHookPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spoilsBagPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boomerangPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dekuLeafPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bombsPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bowPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baitBagPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.magicArmorPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ironBootsPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictoBoxPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tingleTunerPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shieldPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nayruPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dinPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.farorePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox modeBox;
        private System.Windows.Forms.TextBox consoleBox;
        private System.ComponentModel.BackgroundWorker dolphinListener;
        private System.Windows.Forms.PictureBox swordPicture;
        private System.Windows.Forms.PictureBox telescopePicture;
        private System.Windows.Forms.PictureBox sailPicture;
        private System.Windows.Forms.PictureBox wwPicture;
        private System.Windows.Forms.PictureBox grapplingHookPicture;
        private System.Windows.Forms.PictureBox spoilsBagPicture;
        private System.Windows.Forms.PictureBox boomerangPicture;
        private System.Windows.Forms.PictureBox dekuLeafPicture;
        private System.Windows.Forms.PictureBox bombsPicture;
        private System.Windows.Forms.PictureBox bowPicture;
        private System.Windows.Forms.PictureBox baitBagPicture;
        private System.Windows.Forms.PictureBox magicArmorPicture;
        private System.Windows.Forms.PictureBox ironBootsPicture;
        private System.Windows.Forms.PictureBox pictoBoxPicture;
        private System.Windows.Forms.PictureBox tingleTunerPicture;
        private System.Windows.Forms.PictureBox shieldPicture;
        private System.Windows.Forms.PictureBox nayruPicture;
        private System.Windows.Forms.PictureBox dinPicture;
        private System.Windows.Forms.PictureBox farorePicture;
        private System.Windows.Forms.Button testButton;
    }
}

