namespace TWW_Coop
{
    partial class Trainer_Triforce
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
            this.triforceChecklist = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // triforceChecklist
            // 
            this.triforceChecklist.CheckOnClick = true;
            this.triforceChecklist.FormattingEnabled = true;
            this.triforceChecklist.Items.AddRange(new object[] {
            "Triforce Shard 1",
            "Triforce Shard 2",
            "Triforce Shard 3",
            "Triforce Shard 4",
            "Triforce Shard 5",
            "Triforce Shard 6",
            "Triforce Shard 7",
            "Triforce Shard 8"});
            this.triforceChecklist.Location = new System.Drawing.Point(29, 12);
            this.triforceChecklist.Name = "triforceChecklist";
            this.triforceChecklist.Size = new System.Drawing.Size(110, 124);
            this.triforceChecklist.TabIndex = 0;
            this.triforceChecklist.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.triforceChecklist_ItemCheck);
            // 
            // Trainer_Triforce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(172, 151);
            this.Controls.Add(this.triforceChecklist);
            this.Name = "Trainer_Triforce";
            this.Text = "Triforce";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox triforceChecklist;
    }
}