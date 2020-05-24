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
        private readonly int bufferSize = 128;
        private byte[] readBuffer;
     
        public bool isRunning
        {
            get
            {
                return !process.HasExited;
            }
        }

        public DolphinManager()
        {
            process = new Process();
            process.StartInfo.FileName = @"Dolphin\Dolphin.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            started = true;

            readBuffer = new byte[bufferSize];
            ZeroReadBuffer();
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

        public byte[] ReadLineBytes()
        {
            ZeroReadBuffer();
            for (int i = 0; i < readBuffer.Length; i++)
            {
                readBuffer[i] = (byte)process.StandardOutput.Read();
                if (readBuffer[i] == '\n')
                    break;
            }


            return readBuffer;
        }

        public void WriteLine(string msg)
        {
            if (started)
                process.StandardInput.WriteLine(msg);
        }

        private void ZeroReadBuffer()
        {
            for (int i = 0; i < readBuffer.Length; i++)
                readBuffer[i] = 0;
        }




    }
}
