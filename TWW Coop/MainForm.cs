using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TWW_Coop
{
    public partial class MainForm : Form
    {

        public static DolphinManager dolphin;

        public MainForm()
        {
            InitializeComponent();

            dolphin = new DolphinManager();
            string newTitle = dolphin.ReadLine();
            this.Text = newTitle;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        
    }
}
