using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Resources;
using System.IO;

namespace TWW_Coop
{
    public class DolphinManager
    {
        private Process process;
        private bool started = false;
        
        public DolphinManager()
        {
            process = new Process();
            process.StartInfo.FileName = "DOLPHIN_PATH";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            started = true;
        }

        public void Kill()
        {
            process.CloseMainWindow();
            process.Close();
        }

        public string ReadLine()
        {
            if (started)
            {
                return process.StandardOutput.ReadLine();
            }
            return "Dolphin process did not start properly";
        }

        public void WriteLine(string msg)
        {
            if (started)
                process.StandardInput.WriteLine(msg);
        }




    }
}
