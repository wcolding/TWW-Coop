namespace TWW_Coop
{
    partial class Trainer_Bottles
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
            this.bottleBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bottleBox2 = new System.Windows.Forms.ComboBox();
            this.bottleBox3 = new System.Windows.Forms.ComboBox();
            this.bottleBox4 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bottleBox1
            // 
            this.bottleBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bottleBox1.FormattingEnabled = true;
            this.bottleBox1.Items.AddRange(new object[] {
            "No Bottle",
            "Empty Bottle",
            "Red Potion",
            "Green Potion",
            "Blue Potion",
            "Half Soup",
            "Full Soup",
            "Water",
            "Fairy",
            "Firefly",
            "Forest Water"});
            this.bottleBox1.Location = new System.Drawing.Point(91, 31);
            this.bottleBox1.Name = "bottleBox1";
            this.bottleBox1.Size = new System.Drawing.Size(149, 21);
            this.bottleBox1.TabIndex = 0;
            this.bottleBox1.SelectedIndexChanged += new System.EventHandler(this.bottleBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bottle 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bottle 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bottle 3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Bottle 4";
            // 
            // bottleBox2
            // 
            this.bottleBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bottleBox2.FormattingEnabled = true;
            this.bottleBox2.Items.AddRange(new object[] {
            "No Bottle",
            "Empty Bottle",
            "Red Potion",
            "Green Potion",
            "Blue Potion",
            "Half Soup",
            "Full Soup",
            "Water",
            "Fairy",
            "Firefly",
            "Forest Water"});
            this.bottleBox2.Location = new System.Drawing.Point(91, 77);
            this.bottleBox2.Name = "bottleBox2";
            this.bottleBox2.Size = new System.Drawing.Size(149, 21);
            this.bottleBox2.TabIndex = 5;
            this.bottleBox2.SelectedIndexChanged += new System.EventHandler(this.bottleBox2_SelectedIndexChanged);
            // 
            // bottleBox3
            // 
            this.bottleBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bottleBox3.FormattingEnabled = true;
            this.bottleBox3.Items.AddRange(new object[] {
            "No Bottle",
            "Empty Bottle",
            "Red Potion",
            "Green Potion",
            "Blue Potion",
            "Half Soup",
            "Full Soup",
            "Water",
            "Fairy",
            "Firefly",
            "Forest Water"});
            this.bottleBox3.Location = new System.Drawing.Point(91, 123);
            this.bottleBox3.Name = "bottleBox3";
            this.bottleBox3.Size = new System.Drawing.Size(149, 21);
            this.bottleBox3.TabIndex = 6;
            this.bottleBox3.SelectedIndexChanged += new System.EventHandler(this.bottleBox3_SelectedIndexChanged);
            // 
            // bottleBox4
            // 
            this.bottleBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bottleBox4.FormattingEnabled = true;
            this.bottleBox4.Items.AddRange(new object[] {
            "No Bottle",
            "Empty Bottle",
            "Red Potion",
            "Green Potion",
            "Blue Potion",
            "Half Soup",
            "Full Soup",
            "Water",
            "Fairy",
            "Firefly",
            "Forest Water"});
            this.bottleBox4.Location = new System.Drawing.Point(91, 169);
            this.bottleBox4.Name = "bottleBox4";
            this.bottleBox4.Size = new System.Drawing.Size(149, 21);
            this.bottleBox4.TabIndex = 7;
            this.bottleBox4.SelectedIndexChanged += new System.EventHandler(this.bottleBox4_SelectedIndexChanged);
            // 
            // Trainer_Bottles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 226);
            this.Controls.Add(this.bottleBox4);
            this.Controls.Add(this.bottleBox3);
            this.Controls.Add(this.bottleBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bottleBox1);
            this.Name = "Trainer_Bottles";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox bottleBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox bottleBox2;
        private System.Windows.Forms.ComboBox bottleBox3;
        private System.Windows.Forms.ComboBox bottleBox4;
    }
}