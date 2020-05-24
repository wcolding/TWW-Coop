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
using System.Runtime.InteropServices;

namespace TWW_Coop
{
    public partial class MainForm : Form
    {

        public static DolphinManager dolphin;
        private static bool listeningToDolphin;
        private List<string> dolphinInQueue;

        public MainForm()
        {
            InitializeComponent();
            modeBox.SelectedIndex = 0;

            dolphin = new DolphinManager();
            PrintConsole("Opened and attached Dolphin");

            dolphinListener.DoWork += this.DolphinListener;
            listeningToDolphin = true;
            dolphinInQueue = new List<string>();
            dolphinListener.RunWorkerAsync();

            //string newTitle = dolphin.ReadLine();
            //PrintConsole(newTitle);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void modeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PrintConsole(string msg, params object[] args)
        {
            string formatted = String.Format(msg, args);
            consoleBox.Text += formatted + "\r\n";
        }

        private void ParseDolphinMsg(object sender, EventArgs e)
        {

        }

        private void DolphinListener(object sender, DoWorkEventArgs e)
        {
            while (listeningToDolphin && dolphin.isRunning)
            {
                string msg = dolphin.ReadLine();
                byte[] msgB = dolphin.ReadLineBytes();

                PlayerStatus player = new PlayerStatus();
                int playerSize = Marshal.SizeOf(player);
                IntPtr buffer = Marshal.AllocHGlobal(playerSize);
                Marshal.Copy(msgB, 0, buffer, playerSize);
                player = Marshal.PtrToStructure<PlayerStatus>(buffer);
                Marshal.FreeHGlobal(buffer);

                ushort rupees = player.status.currentRupees;

                string msgC = BitConverter.ToString(msgB);

                if (msg == null)
                    msg = "DISCONNECTED";
                
                dolphinInQueue.Add(msgC);

                if (dolphinInQueue.Count > 0)
                {
                    Invoke(new Action(() => { PrintConsole("Dolphin: {0}", dolphinInQueue[0]); }));
                    dolphinInQueue.RemoveAt(0);
                }

                
                    
            }
        }
    }
}
