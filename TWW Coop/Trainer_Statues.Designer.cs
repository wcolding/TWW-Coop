namespace TWW_Coop
{
    partial class Trainer_Statues
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
            this.statueChecklist = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // statueChecklist
            // 
            this.statueChecklist.CheckOnClick = true;
            this.statueChecklist.FormattingEnabled = true;
            this.statueChecklist.Items.AddRange(new object[] {
            "Dragon Tingle Statue",
            "Forbidden Tingle Statue",
            "Goddess Tingle Statue",
            "Earth Tingle Statue",
            "Wind Tingle Statue"});
            this.statueChecklist.Location = new System.Drawing.Point(12, 12);
            this.statueChecklist.Name = "statueChecklist";
            this.statueChecklist.Size = new System.Drawing.Size(140, 79);
            this.statueChecklist.TabIndex = 1;
            this.statueChecklist.SelectedIndexChanged += new System.EventHandler(this.statueChecklist_SelectedIndexChanged);
            // 
            // Trainer_Statues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(165, 104);
            this.Controls.Add(this.statueChecklist);
            this.Name = "Trainer_Statues";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox statueChecklist;
    }
}